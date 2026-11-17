# 手動テスト手順

Windows で [WinFormsEscFocusReturn.sln](../WinFormsEscFocusReturn.sln) を Visual Studio で開き、`WinFormsEscFocusReturn` をスタートアッププロジェクトに設定して F5 で起動します。

| ID | 操作 | 期待結果 |
| --- | --- | --- |
| AC-01 | MainForm で「小さいFormを開く」を押す | メインFormより小さいウィンドウがモードレスで開き、「小さいForm がアクティブ」になる |
| AC-02 | 小さいFormのテキストボックスにフォーカスを移して文字を入力し、そのまま **Esc キー** を押す | **小さいFormは閉じずに入力文字も残り**、MainForm が「メインForm がアクティブ」に戻る（ビープ音も鳴らない） |
| AC-03 | 小さいFormの「操作テスト」ボタンをクリックし、ボタンにフォーカスがある状態で **Esc キー** を押す | 小さいFormは閉じず、MainForm へフォーカスが移る |
| AC-04 | MainForm 側の入力欄にカーソルを置いて文字入力し、小さいFormをクリックして再び **Esc キー** を押す | MainForm がアクティブになり、直前にフォーカスがあった入力欄へそのまま続けて入力できる |
| AC-05 | 小さいFormが開いたまま、MainForm の「小さいFormを開く」をもう一度押す | 2つ目の小さいFormは開かず、既存の小さいFormがアクティブになる |
| AC-06 | `Show(this)` チェックが ON の状態で Esc を押した後の表示を確認する | フォーカスは MainForm にあるが、小さいFormは MainForm の手前に表示され続ける |
| AC-07 | 小さいFormの「閉じる」ボタンで閉じたあと、`Owner を指定して開く` のチェックを外して「小さいFormを開く」を押し、Esc を押す | 小さいFormは閉じずに残り、MainForm が前面（アクティブ）になり、小さいFormはその背面に回る |
| AC-08 | Visual Studio デザイナーで `MainForm.cs` および `SmallToolForm.cs` を開く | いずれもエラーなくデザイナーが表示され、配置や文言を編集できる |
| AC-09 | Windows で Release ビルドし、下記の SmokeTests を実行する | ビルドに成功し、`PASS:` で始まる行を出力して終了コード 0 を返す |

---

## 自動検証（SmokeTests）

```powershell
dotnet build WinFormsEscFocusReturn.sln --configuration Release --warnaserror
dotnet run --project SmokeTests/SmokeTests.csproj --configuration Release --no-build
```

SmokeTests は実際の WinForms ウィンドウを起動し、以下を自動検証します。

- `Show(this)` でモードレス表示（`Modal == false`、`Owner == MainForm`）されること
- `CancelButton` が未設定であること
- 開いたままボタンを再押下しても重複起動しないこと
- `TextBox` および `Button` 上で `ProcessCmdKey(..., Keys.Escape)` が `true` を返し、小さいFormが閉じずに入力状態も維持されること
- `Keys.Enter` などの他キーは横取りしないこと
- 「閉じる」ボタンで `Dispose` された後、`Owner` なし（`Show()`）モードでも同様に閉じずに戻れること
