# 手動テスト手順

Windowsで [WinFormsReusableParts.sln](../WinFormsReusableParts.sln) をVisual Studioで開きます。`WinFormsReusableParts` をスタートアッププロジェクトに設定し、F5で起動します。

| ID | 操作 | 期待結果 |
| --- | --- | --- |
| AC-01 | MainFormで「設定画面を開く」を押す | 親より小さい設定ダイアログがモーダルで開き、Aが選択される。閉じるまで親画面の操作は待機する |
| AC-02 | A、B、C、D、Eを順に選ぶ | 中央は順に X＋Y、X＋Z、W＋X、Y＋Z、TextBox(E)＋X になる。非表示の部品の穴は空かず、上からきれいに詰まる |
| AC-03 | ラジオボタンを素早く連続で切り替える | **画面の白抜け・チカチカ（ちらつき）が一切なく**、一瞬で滑らかに切り替わる |
| AC-04 | AでXの「プレビューを表示する」をONにしてBへ移る | BでもXの「プレビューを表示する」のチェックがそのまま維持されている（共通設定としての保持） |
| AC-05 | AでYをONにして「取得」。Bへ移ってZの「出力に時刻を含める」をONにし、「取得」を押す | 切り替え直後は結果欄がクリアされる。Bの取得結果にはXとZだけが入り、非表示のYは混入しない |
| AC-06 | Cを選び、WとXの項目をチェックして「取得」 | **Wが上、Xが下**の順序で配置され、取得結果にもW、Xの順でチェック項目が表示される |
| AC-07 | Eに `Hello` と入力し、Aへ移ってEに戻る | TextBoxに `Hello` がそのまま保持されている |
| AC-08 | Visual Studioデザイナーで `ModeSelectForm.cs` を開く | 中央パネル内に常駐する各パーツ（`partX`〜`partE`）が確認でき、プロパティを直接編集できる |
| AC-09 | A〜Eを25回以上連続で切り替える | コントロールの重複生成やエラーが発生せず、安定して動作し続ける |
| AC-10 | `Views/Parts/PartXControl.cs` のデザイナーを開く | 部品単体のGroupBoxやCheckBoxを個別に編集でき、全モードへ即座に反映される |
| AC-11 | WindowsでReleaseビルドし、下記のSmokeTestsを実行する | ビルドに成功し、`PASS:` で始まる行を出力して終了コード0を返す |
| AC-12 | READMEの設計解説を読む | 破棄再生成方式と常駐可視性切替方式の比較、ちらつき解消の仕組み、状態管理の違いを理解できる |

---

## 配置と操作の確認

- 設定ダイアログを最小サイズまで縮め、パネル内のスクロールバーで下の部品までスクロールできることを確認します。「取得」「閉じる」ボタンは下部に固定されます。
- Tabキーと矢印キーでモードと部品内のCheckBoxを移動・操作できます。Escキーでダイアログが閉じ、MainFormに戻ります。
- Windowsの表示倍率（DPI）を100%、150%、200%に変更しても、文字欠けやコントロールの重なりが発生しないことを確認します。

---

## 自動検証（SmokeTests）

```powershell
dotnet build WinFormsReusableParts.sln --configuration Release --warnaserror
dotnet run --project SmokeTests/SmokeTests.csproj --configuration Release --no-build
```

SmokeTestsは実際のWinFormsダイアログを開き、A〜Eの表示切り替え、配置順（CでのW→X、EでのTextBox→X）、Xのチェック状態の保持、現在表示中部品のみの取得集約、Eのテキスト保持、25回連続切り替えを自動検証します。
