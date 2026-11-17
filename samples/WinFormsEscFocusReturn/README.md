# WinForms：小さいFormを閉じずに Esc キーでメインFormへフォーカスを移す

メインFormのボタンから開いた小さいForm（ツールウィンドウ等）で **Esc キーを押したとき、小さいFormを閉じずにメインFormへフォーカスを移す** 学習用サンプルです。

既存の `src/Csharp.csproj` や他のサンプルとは独立したソリューションであり、追加の NuGet パッケージは使いません。

---

## 最初に動かす

Windows 環境、Visual Studio（「.NET デスクトップ開発」ワークロード）、.NET 10 SDK に対応しています（ターゲットフレームワーク: `net10.0-windows`）。

1. [WinFormsEscFocusReturn.sln](WinFormsEscFocusReturn.sln) を Visual Studio で開きます。
2. `WinFormsEscFocusReturn` をスタートアッププロジェクトに設定し、F5 で起動します。
3. 「小さいFormを開く」を押します。
4. 小さいForm内のテキストボックスやボタンにフォーカスがある状態で **Esc キー** を押します。
   - **小さいFormは閉じずにそのまま残り、上部の状態表示が「メインForm がアクティブ」に切り替わります**。
5. メインFormの入力欄をクリックして文字を入力したあと、もう一度小さいFormをクリックしてから Esc を押すと、メインForm側の直前のフォーカス位置に入力が戻ります。

Windows のターミナルからビルド・実行する場合：

```powershell
dotnet build WinFormsEscFocusReturn.sln --configuration Release --warnaserror
dotnet run --project WinFormsEscFocusReturn/WinFormsEscFocusReturn.csproj
dotnet run --project SmokeTests/SmokeTests.csproj --configuration Release --no-build
```

> macOS 等の非 Windows 環境でコンパイル確認だけ行う場合は `-p:EnableWindowsTargeting=true` を付けてビルドします（実行には Windows 環境が必要です）。

---

## 設計のポイント（なぜこの実装なのか）

### 1. `ShowDialog()` ではなく `Show(this)`（または `Show()`）で開く
`ShowDialog()` で開いたフォームは **モーダルダイアログ** になるため、そのフォームを閉じるまでメインFormへフォーカスを移すことができません。  
小さいFormを閉じずにメインFormへフォーカスを戻したい場合は、必ず **モードレス表示（`Show`）** にします。

```csharp
// Owner を指定してモードレス表示（メインFormより常に手前に残る）
smallForm.Show(this);
```

### 2. `KeyDown` ではなく `ProcessCmdKey` で Esc を捕捉する
フォーム上に `TextBox` や `Button` などの子コントロールがあると、既定ではフォームの `KeyDown` イベントは発火しません（`KeyPreview = true` を設定する必要があり、さらに `e.SuppressKeyPress = true` を忘れると Windows のビープ音が鳴ります）。

`SmallToolForm` で `ProcessCmdKey` をオーバーライドすれば、`KeyPreview` の設定漏れを防ぎつつ、どのコントロールにフォーカスがあっても確実に `Keys.Escape` を捕捉して処理済みにできます。

```csharp
protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
    if (keyData == Keys.Escape)
    {
        ReturnFocusToMainForm();
        return true; // キー処理を完了し、ビープ音や他の既定動作を防ぐ
    }

    return base.ProcessCmdKey(ref msg, keyData);
}
```

### 3. `Focus()` ではなく `Activate()` でメインFormへフォーカスを移す
別のフォームへフォーカスを移すときは `mainForm.Focus()` ではなく **`mainForm.Activate()`** を呼びます。

```csharp
Form? target = Owner ?? _returnTarget;
if (target is not null && !target.IsDisposed)
{
    target.Activate();
}
```

### 4. `Owner` あり（`Show(this)`）と `Owner` なし（`Show()`）の Z オーダーの違い
本サンプルではメインFormのチェックボックスで 2 つの開き方を切り替えられます。

| 開き方 | `Owner` | Esc 後のフォーカス | 重なり順（Z オーダー） | 向いている用途 |
| --- | --- | --- | --- | --- |
| `smallForm.Show(this)` | メインForm | メインFormへ移動 | 小さいFormが**常に手前に残る** | 検索窓・ツールパレット・補助パネル |
| `smallForm.Show()` | `null` | メインFormへ移動 | メインFormが**前面に出て、小さいFormは後ろに隠れる** | 独立したサブウィンドウ |

---

## ドキュメントと関連ファイル

- クラス構成・フォーカス遷移シーケンス: [docs/architecture.md](docs/architecture.md)
- 手動テスト手順・自動検証（SmokeTests）: [docs/manual-test-cases.md](docs/manual-test-cases.md)
- 解説記事: [articles/winforms-esc-focus-return.md](../../articles/winforms-esc-focus-return.md)
- メインForm: [MainForm.cs](WinFormsEscFocusReturn/Forms/MainForm.cs)
- 小さいForm: [SmallToolForm.cs](WinFormsEscFocusReturn/Forms/SmallToolForm.cs)
