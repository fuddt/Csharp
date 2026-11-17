# pandas 2.3.3 → 3.1.1 浮動小数点の最下位桁差異に関する調査

> 調査メモ／2026年11月18日 ｜ CSV・NumPyバイナリ比較・原因切り分け

## 要約

pandas 2.3.3 と 3.1.1 で生成した CSV について、浮動小数点数の最後の 1 桁が異なる事象が報告された。さらに、DataFrame を NumPy 配列へ変換し、`with open(..., 'wb')` で書き出したバイナリーファイルも一致しなかった。

公式情報から、3.1.0 で `read_csv()` の浮動小数点解析精度が改善され、`float_precision` の各モードが同一コンバーターへ統一されたことを確認した。また、特定条件の `groupby().sum()/mean()` について、最下位桁の計算結果が従来版と異なり得る変更もある。両方とも原因候補だが、現時点で実データによる特定はできていない。

---

## 1. 現在判明している事実と未確認事項

### 確認済みの事象（ユーザー報告）

- 比較対象：pandas 2.3.3 → pandas 3.1.1。
- 2系・3系で出力した CSV の浮動小数点の末尾 1 桁が異なる。
- DataFrame を NumPy 配列にしたものを、バイナリーモード（`wb`）で書き出してもファイルが一致しない。

### まだ未確認

- 両環境で同一の入力 CSV・同一の処理・同一の順序を使っているか。
- 差が発生した最初の時点（`read_csv()` 直後か、計算／集計後か、`to_csv()` 時か）。
- 比較した数値列の `dtype`（`float64` / `float32` / その他）、NumPy バージョン、CSV 読込オプション。
- 書き込み式の完全なコード（`np.array(df)` を直接 `write` したか、`tobytes()` を使用したか）。

---

## 2. 「CSV文字列の差」と「内部値の差」を区別する

CSV の末尾 1 桁の相違だけでは、内部の `float64` が違うと断定できない。例えば `0.12345678901234567` と `0.12345678901234566` を Python の `float` に変換すると、同じ内部ビット列になる。したがって、CSV テキストを比較した後、値の 16 進数表現または 64bit の生データを比較する必要がある。

また、`wb` はファイルを書き込むモードの指定にすぎない。`np.array(df)` の `dtype` が `object` の場合、`tobytes()` 等の生バイト列には Python オブジェクトへの参照値が含まれ得る。そのようなバイナリーの不一致は、数値の不一致を意味しない。列の `dtype`・配列の `shape`・順序を固定して比較する。

---

## 3. pandasの公式変更履歴にある関連項目

### 3.1 CSV読み込み時の浮動小数点変換

pandas 3.1.0 の公式リリースノートには「`read_csv()` の浮動小数点解析精度を改善」（GH #64395）と記載されている。さらに `read_csv()` の `float_precision` 引数は非推奨となり、従来の `high` / `legacy` / `round_trip` はいずれも同じコンバーターを使うようになった。pandas 3.1.1 で `float_precision='high'` を指定しても 2.3.3 時代の変換方法へ戻るわけではない。

この変更は同じ CSV の小数文字列を `float64` に変換した結果が、最下位桁で異なり得るという仮説と整合する。ただし、ユーザーの CSV で実際に再現するかは未検証。

### 3.2 groupby集計アルゴリズム

pandas 3.1.0 の公式リリースノートには、浮動小数点列で「ソート済みのグループキー」を扱う `DataFrameGroupBy.sum()/mean()` について、高速化で Kahan 補償付き加算を使わなくなったため、末尾数桁が従来版と異なる場合があると明記されている（GH #65103）。該当する `groupby` 処理を含む場合は、読み込み直後が一致しても集計後に差が出る可能性がある。

### 3.3 型推論・pandas 3.1.1

pandas 3.0 以降、文字列のデフォルト `dtype` に変更がある。DataFrame 全体を `np.array(df)` に変換する場合、混在型・拡張 `dtype` の影響を受ける可能性がある。pandas 3.1.1 は 3.1 系の不具合修正版だが、ここで列挙した差異の原因が 3.1.1 個別の修正であると確認できたわけではない。

---

## 4. 再現検証：両環境で同じ入力CSVから比較する

以下を pandas 2.3.3 環境と 3.1.1 環境でそれぞれ実行する。`input.csv` と列名 `value` は実データに置き換え、現行処理で `read_csv()` に渡しているオプションもそろえる。最初は「読み込み直後」の DataFrame を対象とする。

```python
# read_csv()直後のfloat64内部ビット列を固定形式で保存する
import sys
import pandas as pd
import numpy as np

print("Python:", sys.version.split()[0])
print("pandas:", pd.__version__, "NumPy:", np.__version__)

# 両方の環境で同じ入力ファイル・同じ読み込みオプションを使用
df = pd.read_csv("input.csv", engine="c")
column = "value"  # 実際に差が出た列名
print("DataFrame dtypes:\n", df.dtypes)

# 全列のnp.array(df)の型も確認する（object型に注意）
arr_all = np.asarray(df)
print("全列shape:", arr_all.shape, "dtype:", arr_all.dtype)

# 比較対象の列の値をfloat64として統一
# 元のdtypeも必ず確認し、変換前から異なっていないか調べる
values = np.ascontiguousarray(
    df[column].to_numpy(dtype=np.float64)
)
print("対象列dtype:", df[column].dtype)
print("件数:", values.size)
print("先頭値:", repr(values[0]) if values.size else "(empty)")
print("先頭hex:", float(values[0]).hex() if values.size else "(empty)")

# 64bit浮動小数点のビット列そのものを書き出す
# 同じOS/CPUのリトルエンディアン環境で統一する例
values_le = values.astype("<f8", copy=False)
major = pd.__version__.split(".")[0]
with open(f"readcsv_pandas{major}.bin", "wb") as f:
    f.write(values_le.tobytes())
```

上の 2 つの `.bin` を比べる際は、同じデータ件数・同じ行順・同じ列・同じ `dtype` であることを確認する。異なっていれば、CSV 出力の書式だけでなく、読み込み時点で内部表現に差が生じている可能性が高い。

### 4.1 生バイナリーの差分位置を特定する

```python
# 2つのfloat64生データを別環境でも読み出して比較
import numpy as np

old = np.fromfile("readcsv_pandas2.bin", dtype="<f8")
new = np.fromfile("readcsv_pandas3.bin", dtype="<f8")

# 最初に件数を確認。異なる場合、値の位置対応から見直す
assert old.shape == new.shape, (old.shape, new.shape)

# ビット単位の完全一致で比較（NaNペイロードや符号付きゼロも区別）
old_bits = old.view("<u8")
new_bits = new.view("<u8")
diff_idx = np.flatnonzero(old_bits != new_bits)

print("差分件数:", len(diff_idx), "/", len(old))
for i in diff_idx[:10]:
    # 先頭10件のみ報告。全件は別途ログに残す
    print(i, repr(old[i]), repr(new[i]),
          float(old[i]).hex(), float(new[i]).hex())
```

### 4.2 切り分け結果の読み方

- **A．読み込み直後の `float64` 生バイナリーが異なる** → `read_csv()` のパーサー差、型指定、オプション、入力ファイルの不一致を優先調査。
- **B．読み込み直後は一致し、`groupby` 後に異なる** → 集計アルゴリズム変更（ソート済みグループキーと `sum`/`mean`）の影響を検証。
- **C．内部ビット列は一致し、`to_csv()` の文字列だけ違う** → `float` 書式や CSV 出力処理を検証。
- **D．`np.array(df)` 全体だけ異なる** → `object` 型、混在型、列順・行順、ヘッダー／インデックスなどを確認。

---

## 5. 対処方針と注意点

厳密な完全互換（従来生成物とバイト単位一致）が必須であれば、まず pandas 2.3.3＋依存ライブラリを固定した既存環境を維持するのが確実。3.1.1 での無条件の完全互換設定は確認できていない。

出力の桁数を揃える目的なら、双方で `df.to_csv('output.csv', index=False, float_format='%.17g')` などを指定できる。ただしこれは「有効数字 17 桁で出力する」指定であり、2.3.3 の既定出力文字列を再現する保証はない。逆に 15 桁へ丸めて違いを隠すのは、原因究明ではない。

pandas 2.3.3 側の `read_csv(float_precision='round_trip')` は診断上の比較候補になるが、3.1.1 側では同じ引数で旧実装に戻せない。値の意味上の一致と、内部 64bit の完全一致と、CSV テキストの一致を別の受け入れ条件として扱うべき。

---

## 6. 次に収集すると特定が進む情報

- 末尾が異なった実際の CSV の値（旧・新を各 1 件以上）。
- `input.csv` の同一性（可能ならハッシュ値）と `read_csv()` の完全な呼び出し。
- 差分がある列の `dtype` と、読み込み直後の各値の `float.hex()`。
- 対象処理での `groupby().sum()/mean()` などの使用有無。
- `np.array(df)` からバイナリーへ書き込んだ正確な 1 行と NumPy バージョン。

---

## 7. 一次情報（公式資料）

- [pandas 3.1.0 Release Notes](https://pandas.pydata.org/docs/whatsnew/v3.1.0.html)
- [pandas 3.1.1 Release Notes](https://pandas.pydata.org/pandas-docs/stable/whatsnew/v3.1.1.html)
- [pandas read_csv API](https://pandas.pydata.org/docs/reference/api/pandas.read_csv.html)
- [pandas PR #64666（float_precision非推奨化）](https://github.com/pandas-dev/pandas/pull/64666)

> 注：本書は対話中の観測情報と公式変更履歴を整理した調査メモであり、再現用の実 CSV・旧新バイナリーファイルを直接比較した報告ではない。原因確定には第 4 章の検証が必要。
