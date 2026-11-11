# WinFormsで部品を再利用する可変UI

メイン画面の「設定画面を開く」から、5モードの設定ダイアログを開けます。AとBは同じ種類の部品Xを使います。AでXをチェックしてからBに移ると、BにもXは表示されますが、チェックは初期状態です。Eで入力したテキストは、同じダイアログ内でEに戻ると復元されます。この二つの操作で、部品の定義、画面の実体、Modelが保持するデータの違いを確認できます。

## 起動する

Csharpリポジトリの既存プロジェクトに合わせて.NET 10を選びました。Windowsでの実行には.NET 10 Desktop Runtimeが必要です。ソースをビルドし、デザイナーで編集する場合は、Windows版Visual Studio 2026で「.NET デスクトップ開発」と.NET 10 SDKを用意します。 [Microsoft Learnのセットアップ手順](https://learn.microsoft.com/ja-jp/dotnet/desktop/winforms/get-started/create-app-visual-studio)

1. [WinFormsReusableParts.sln](WinFormsReusableParts.sln)をVisual Studioで開き、`WinFormsReusableParts`をスタートアッププロジェクトに設定します。
2. F5で起動し、「設定画面を開く」を押します。ダイアログはAから始まります。
3. AでXとYの項目をチェックして「取得」を押します。Bに切り替え、Xだけをチェックして再度「取得」を押すと、Bで選んだ項目が表示されます。
4. Eで `Hello` と入力し、Aを経由してEへ戻ります。TextBoxに `Hello` が復元されます。

設定画面では `ShowDialog(this)` を使います。ダイアログを操作している間は親画面が待機するため、同時に複数の設定画面を開く場合の状態管理を持ち込まずに、ページ間の違いを試せます。親の `MainForm` が `using` でダイアログを所有し、閉じた後に破棄します。

## ページと部品を分ける理由

| モード | 上の部品 | 下の部品 |
| --- | --- | --- |
| A | X プレビュー | Y 入力確認 |
| B | X プレビュー | Z 出力 |
| C | W 補助表示 | X プレビュー |
| D | Y 入力確認 | Z 出力 |
| E | 最後の入力を表示するTextBox | X プレビュー |

A〜Dは添付図の組み合わせに沿っています。Eの「TextBox＋X」と各CheckBoxの文言はデモ用の仮仕様です。チェックを付けると、取得結果にその項目の表示文字列が入ります。

ページ単位の `PageAView`〜`PageEView` は、そのモードにどの部品を置くか、どこに置くかを定義します。部品単位の `PartXControl`、`PartYControl`、`PartZControl`、`PartWControl` は、それぞれのGroupBox、CheckBox、チェック済み文字列の取得を担当します。

AとBのデザイナーコードには、それぞれ `new PartXControl()` があります。**同じ型を使うのでXのUI定義を一か所で直せます。別々に生成するので、それぞれが独自の `CheckBox.Checked` を持ちます。** Cでは同じXをWの下に置いており、部品の機能を再利用しながら位置を変更できます。

ページに共通する呼び出しは `ICheckedTextPage.GetCheckedTexts()` の1つです。この契約をインターフェースで表すと、各ページはWinFormsの `UserControl` から直接派生でき、コンストラクターと配置を独立して追えます。BasePageへ配置や状態まで持たせると、あるモードの変更が共通クラスを経由して別のモードにも及び、デザイナーで調整する範囲が分かりにくくなります。

## クラスの責務

| クラス | 担当 |
| --- | --- |
| `MainForm` | 設定ダイアログを開き、閉じた後に破棄する |
| `ModeSelectForm` | 選択中のモード、ページの差し替え、取得結果の表示を担当する。ダイアログ単位でModelとControllerを用意する |
| `PageAView`〜`PageEView` | 部品の構成と配置を決め、そのページのチェック結果を集める。Eだけが入力の表示と変更通知も担当する |
| `PartXControl`・`PartYControl`・`PartZControl`・`PartWControl` | 部品内にあるCheckBoxのうち、チェック済みの項目の `Text` を返す |
| `ICheckedTextPage` | ダイアログがどのページにも同じ方法でチェック結果を問い合わせられるようにする |
| `IReadOnlyModeModel` | EのViewが初期値を読めるよう、`LastEInput` のgetterを公開する |
| `ModeController` | EのViewから入力変更を受け、Modelの更新メソッドを呼ぶ |
| `ModeModel` | 現在のダイアログにおけるEの最新入力を保持する。同じ文字列の書き込みは省く |

ソースへのリンクと依存関係図は、[クラス構成と処理の流れ](docs/architecture.md)にまとめています。

## 取得ボタンが読む範囲

`ModeSelectForm` は、表示中のページの参照を1つ保持します。「取得」が押されると、そのページの `GetCheckedTexts()` を呼びます。たとえばBは自分のXとZの結果を集め、部品は自分のCheckBoxの `Text` を返します。親フォームがA〜EそれぞれのCheckBox名や組み合わせを知る必要はありません。

取得結果は呼び出し時点の文字列の一覧です。チェックを変えた後は「取得」を押すと結果が更新されます。モードを変えると直前のページの結果欄も消えます。チェックがなければページは空の一覧を返し、結果欄に「チェックされた項目はありません。」と表示します。

`Text` は利用者が読む文言です。将来、選択項目をファイルに保存したり業務処理へ渡したりするなら、固定の内部IDと表示用の `Text` を別々に持つと、文言変更や翻訳が処理結果に影響しにくくなります。

## ページの寿命と、Eの入力が戻る仕組み

ラジオボタンがチェックされたとき、選択が変わった場合に限って対応するページを生成します。新しいページをPanelに追加できたら、古いページを取り外して `Dispose()` します。その子である共通部品とCheckBoxも一緒に破棄されます。戻ってきたページのCheckBoxは新しく作られるため、デザイナーで設定した初期値から始まります。生成やPanelへの追加が失敗した場合は、候補を破棄し、元のページとラジオボタンの選択を保ちます。

EのTextBoxを編集すると、`PageEView` は `TextChanged` で `ModeController.ChangeEInput()` を呼びます。Controllerが `ModeModel.SetLastEInput()` を呼び、Modelが最新の文字列を保持します。空欄に戻した場合もその空文字列を保存します。

Eを再表示すると、新しい `PageEView` は `IReadOnlyModeModel.LastEInput` から文字列を読み、TextBoxに表示します。初期値を入れてから `TextChanged` を接続するので、復元の代入がModelへの変更依頼になりません。Modelでも同値更新を省きます。変更通知はそのViewが所有するTextBoxからだけ届き、Modelの寿命はダイアログに合わせています。ダイアログを開き直すとEは空欄から始まります。

## デザイナーで編集する

1. ソリューションをビルドします。ソリューションエクスプローラーで `Views/Pages/PageCView.cs` を右クリックし、「デザイナーの表示」（Shift+F7）を選びます。
2. C上で `partX` を選び、ドラッグまたはプロパティウィンドウで `Location` や `Size` を変更します。AとBの `partX` の配置はそれぞれのページで編集します。
3. X自体のGroupBoxやCheckBoxを編集する場合は、`Views/Parts/PartXControl.cs` のデザイナーを開きます。変更した部品定義は、次のビルドでXを使う各ページに反映されます。
4. `ModeSelectForm.cs` のデザイナーではラジオボタン、中央Panel、結果欄を編集します。実行時の `OnLoad` で初期ページを入れるため、デザイナー上では中央が空です。

| 要素 | 役割と設定 |
| --- | --- |
| `Panel` | ダイアログ中央の差し替え先。上下の共通領域を除いた部分を `Dock = Fill` で占める |
| `GroupBox` | 関連する操作部品を見出しでまとめる。CheckBoxは部品内のGroupBoxに配置する |
| `Dock` | 親のどの領域を占めるかを決める。ページ本体はPanelに `Fill` で入れ、ページ内の部品は `None` で配置する |
| `Location`・`Size` | ページ内での部品の座標・寸法。座標は直接の親を基準にする |
| `Anchor` | 親がリサイズしたときに距離を保つ辺。ページ内の部品は `Top, Left` を基準にする |

部品を追加するには、引数なしコンストラクターを持つUserControlを作り、GroupBoxとCheckBoxを配置します。ビルド後、対象ページのツールボックスからその部品を配置し、ページの `GetCheckedTexts()` に新しい部品の結果を加えます。

モードを追加するには、新しいUserControlに部品を配置し、`ICheckedTextPage` を実装します。ダイアログの同じGroupBoxへラジオボタンを追加し、`Tag` と共通の `CheckedChanged` を設定します。最後に `ModeSelectForm.CreatePage()` にモードとViewの対応を加えます。

## この設計の利点と制約

部品の見た目や選択肢を各ページに複製せずに済みます。ページ単位のデザイナーを見れば配置全体が分かり、部品単位のデザイナーを見ればその選択肢が分かります。その分、画面と部品でファイル数は増えます。機能が違う部品を見た目だけで共通化すると、部品内の条件分岐が増え、利用ページの影響範囲が広がります。

座標による自由配置は、モードごとの位置の違いを表しやすい方法です。ウィンドウを縮めても自動で並び替わらないので、ダイアログに最小サイズを設け、各ページの `AutoScroll` を有効にしています。高DPIや大きなフォントでの文字収まりは、利用するWindows環境で確認します。

切り替えごとにViewを生成する方式では、画面が大きくなると生成コストが増えます。また、保存が必要な入力はModelに保持する項目と期間を決める必要があります。このサンプルでは、Eの入力だけをダイアログの間保持し、チェック状態はページの寿命に合わせています。

## ビルドと動作確認

Windowsのターミナルで、このディレクトリから実行します。

```powershell
dotnet build WinFormsReusableParts.sln --configuration Release --warnaserror
dotnet run --project WinFormsReusableParts/WinFormsReusableParts.csproj
dotnet run --project SmokeTests/SmokeTests.csproj --configuration Release --no-build
```

SmokeTestsは実際のWinFormsダイアログを開きます。A〜Eの切り替え、取得対象の範囲、部品インスタンスの独立性、旧ページの破棄、Eの復元、ダイアログ再起動時の初期値、切り替え失敗からの復帰を検証します。Windowsでのビルドと実行結果は、[専用のGitHub Actions](../../.github/workflows/winforms-reusable-parts.yml)のログで確認できます。

macOS arm64、.NET SDK 10.0.102では、次のWindows向けクロスビルドが警告0件・エラー0件で通りました。

```bash
dotnet build WinFormsReusableParts.sln --configuration Release --warnaserror -p:EnableWindowsTargeting=true
```

このコマンドで確認するのはコンパイルです。画面操作とVisual Studioのデザイナー操作にはWindowsを使います。 [Microsoft LearnのWindowsターゲティングの説明](https://learn.microsoft.com/ja-jp/dotnet/core/tools/sdk-errors/netsdk1100)

[手動テスト手順](docs/manual-test-cases.md)には、要件ごとの操作と期待結果、デザイナー編集、画面サイズとDPIの確認方法を記載しています。
