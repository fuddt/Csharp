# WinForms：UserControlを差し替える可変UI

MainFormの上部・下部を共通領域として残し、中央だけを6種類のUserControlで差し替える学習用サンプルです。各ViewのGroupBoxは`Location`と`Size`で自由配置し、Visual Studioのデザイナーで編集できます。

既存の`src/Csharp.csproj`とは別のソリューションです。既存の教材コードやプロジェクト設定を変更せず、このディレクトリだけでビルドできます。アプリ・検証コードともに追加のNuGetパッケージは使いません。

## 最初に動かす

必要な環境はWindows、Visual Studio 2026の「.NETデスクトップ開発」ワークロード、.NET 10 SDKです。対象フレームワークは`net10.0-windows`です。

1. [WinFormsDynamicUi.sln](WinFormsDynamicUi.sln)をVisual Studioで開きます。
2. `WinFormsDynamicUi`プロジェクトをスタートアッププロジェクトに設定します。
3. F5またはCtrl+F5で起動します。初期画面はモードAです。
4. 上部のラジオボタンA〜Fを選び、中央のUIだけが入れ替わることを確認します。
5. 下部の「共通メモ」に入力して切り替えます。共通メモは残り、各モード内部の入力は初期化されます。下部の生成回数も1ずつ増えます。

Windowsのターミナルから起動する場合は、このREADMEのあるディレクトリで実行します。

```powershell
dotnet build WinFormsDynamicUi.sln --configuration Release
dotnet run --project WinFormsDynamicUi/WinFormsDynamicUi.csproj
```

## 画面とクラスの役割

```text
MainForm : Form
├─ groupBoxTop              共通・固定（Dock = Top）
│  └─ radioButtonA〜F        同じGroupBox内で排他的に選択
├─ panelCenter              可変領域（Dock = Fill / AutoScroll = false）
│  └─ ModeAView〜ModeFView   選択された1つだけを生成・表示
│     └─ 専用GroupBox群      Location / Sizeによる自由配置
└─ groupBoxBottom           共通・固定（Dock = Bottom）
   ├─ textBoxCommonMemo     切り替えても残る入力
   ├─ labelCurrentMode     選択中のモード・生成回数
   └─ buttonClose
```

「固定」は、モードを切り替えても共通領域のインスタンスと役割を維持する、という意味です。フォームのリサイズ時には共通領域の横幅と中央領域の広さが変わります。

| クラス／ファイル | 担当 |
| --- | --- |
| [Program.cs](WinFormsDynamicUi/Program.cs) | WinFormsの初期化とMainFormの起動 |
| [MainForm.cs](WinFormsDynamicUi/MainForm.cs) | 選択イベント、Viewの生成・取り外し・Dispose・追加 |
| [MainForm.Designer.cs](WinFormsDynamicUi/MainForm.Designer.cs) | 上部・中央・下部の配置と共通部品 |
| `Views/ModeAView.cs`〜`ModeFView.cs` | 各View内で完結する小さな操作イベント |
| `Views/Mode?View.Designer.cs` | 各モードのGroupBox・操作部品・座標・サイズ |
| `MainForm.resx`、`Views/Mode?View.resx` | デザイナーが利用するリソース用ファイル（初期状態では追加リソースなし） |
| [SmokeTests/Program.cs](SmokeTests/Program.cs) | Windows上で実際のForm・Controlを生成する自動検証 |

各Viewは`UserControl`を直接継承する独立したクラスです。専用のBaseクラス、Model、Controller、DIコンテナー、画面キャッシュは設けていません。UI構築と差し替えを追いやすくするため、小さな表示処理は各Viewのイベントハンドラーに置いています。

MainFormが各モードについて知るのは、生成するViewの型だけです。内部のGroupBoxやTextBoxの位置を操作しません。業務処理を追加する段階で必要になったら、その処理を別クラスへ取り出せます。

## 6モードの違い

| モード | View | GroupBox数と配置 | 操作例 |
| --- | --- | --- | --- |
| A：基本入力 | [ModeAView](WinFormsDynamicUi/Views/ModeAView.cs) | 3個。横方向に並べ、一部を下へずらす | 名前・数量・カテゴリを表示 |
| B：絞り込み | [ModeBView](WinFormsDynamicUi/Views/ModeBView.cs) | 2個。左に条件、右に広い結果欄 | サンプル値25・55・80を「以上／以下」で絞り込み |
| C：座標・角度 | [ModeCView](WinFormsDynamicUi/Views/ModeCView.cs) | 3個。上段に2個、下段に1個 | 座標の表示、スライダーで角度変更 |
| D：項目選択 | [ModeDView](WinFormsDynamicUi/Views/ModeDView.cs) | 2個。右の出力欄を下へずらす | 項目選択・全選択・選択内容の表示 |
| E：メモ編集 | [ModeEView](WinFormsDynamicUi/Views/ModeEView.cs) | 3個。広い入力欄、縦長の表示欄、下段の設定 | メモを見出し付き／なしでプレビュー |
| F：色・サイズ | [ModeFView](WinFormsDynamicUi/Views/ModeFView.cs) | 3個。高さの異なる段違い配置 | 見本Panelの色と大きさを変更 |

Aの「通知／履歴」、Cの「グリッド／スナップ」は、異なる部品配置を練習するためのチェックボックスです。設定の選択だけを行い、通知・履歴保存・描画の処理は実装していません。Dも実ファイルを操作せず、選択した項目名を表示するだけです。

## デザイナーで配置を編集する

1. ソリューションを一度ビルドします。
2. ソリューションエクスプローラーで`WinFormsDynamicUi/Views/ModeAView.cs`などを右クリックし、「デザイナーの表示」（Shift+F7）を選びます。
3. GroupBoxをドラッグし、プロパティウィンドウの`Location`と`Size`を調整します。GroupBoxの中へ部品を配置すると、その部品の`Location`はGroupBox内の座標になります。
4. GroupBoxの`Anchor = Top, Left`、`Dock = None`を維持します。
5. Viewの`AutoScroll = True`を維持します。配置を大きく変更した場合は`AutoScrollMinSize`も確認してください。このサンプルでは余白を含むスクロール範囲を各Viewに明示しています。
6. 起動して該当モードを選び、ウィンドウを縮めてスクロールも確認します。

`MainForm.cs`のデザイナーでは、共通の上下領域と空の中央Panelを編集します。モード画面は実行時の`OnLoad`で最初に生成するため、MainFormのデザイナー上に6モードは並びません。各モードはそれぞれのUserControlのデザイナーを開いて編集します。

各画面は通常の`partial`クラス、引数なしコンストラクター、`InitializeComponent()`、`.Designer.cs`、`.resx`に分かれています。画面の構築は`InitializeComponent()`、操作イベントは通常の`.cs`が担当します。Designerファイルを日常的に手編集する必要はありません。

| 対象 | 主なプロパティ |
| --- | --- |
| MainFormの上部／下部GroupBox | `Dock = Top / Bottom` |
| 中央Panel | `Dock = Fill`、`AutoScroll = False` |
| 表示するUserControl | 追加時に`Dock = Fill`、デザイナーで`AutoScroll = True` |
| View内のGroupBox | `Location / Size`、`Anchor = Top, Left`、`Dock = None` |

TableLayoutPanelやFlowLayoutPanelは使いません。フォームを縮めてもGroupBoxは自動で並び替わりません。Viewのスクロールで、表示領域に収まらない部品へアクセスします。

## 切り替え時の寿命

[MainForm.ShowMode](WinFormsDynamicUi/MainForm.cs)は次の順番で処理します。

1. 中央Panelのレイアウト処理を一時停止する。
2. 以前のViewがあれば、Panelから取り外す。
3. 以前のViewを`Dispose()`し、参照をクリアする。
4. 選択したモードのViewを`new`で生成する。
5. `Dock = Fill`を指定して中央Panelへ追加する。
6. レイアウト処理を再開する。

`Controls.Remove()`や`Controls.Clear()`だけでは、取り外したViewの`Dispose()`は行われません。このサンプルは古いViewを明示的に破棄します。Viewが所有する子Controlも破棄の対象になります。フォームを閉じるときは、フォームから中央Panel、最後に表示していたViewへと破棄が伝わります。

ラジオボタンを切り替えると、外れた側と選ばれた側で`CheckedChanged`が発生します。ハンドラーは`Checked == true`の側だけを処理して、1回の切り替えで1つのViewを生成します。

この寿命設計では、別モードから戻ったときの入力状態を保存しません。入力を保持したい場合は、破棄前にUI外へ保存して新しいViewに渡す設計が別途必要です。また、将来タイマーやUI外の長寿命オブジェクトへのイベント購読を追加した場合は、それらの停止・購読解除もViewの破棄処理に含めてください。

## ビルドと動作の検証

Windowsでは次のコマンドで、ソリューションのビルドと自動検証を行えます。

```powershell
dotnet build WinFormsDynamicUi.sln --configuration Release --warnaserror
dotnet run --project SmokeTests/SmokeTests.csproj --configuration Release --no-build
```

SmokeTestsは外部テストフレームワークを使わないコンソールプログラムです。STAスレッドで実際のMainFormを表示し、以下を検証します。成功時は`PASS`を出力して終了コード0、失敗時は理由を出力して終了コード1を返します。

- 初期モードA、6つのラジオボタン、中央に1つだけのView。
- A→B→C→D→E→F→Aを5周（30回の切り替え、初回を含む31回の生成）。
- 以前のViewとその子Controlの破棄、新しいインスタンスの生成。
- 共通領域・共通入力の保持、戻ったモードの入力初期化。
- 各モードの操作結果と、最小ウィンドウサイズでの縦横スクロール。
- フォーム終了時の最後のViewの破棄。

リポジトリの[専用GitHub Actions](../../.github/workflows/winforms-dynamic-ui-sample.yml)も同じコマンドを`windows-latest`で実行します。このサンプルまたは専用ワークフローの変更時に起動します。

macOS／Linuxでコンパイルだけを確認する場合は、Windows用ターゲティングパックのダウンロードを許可して実行します。

```bash
dotnet build WinFormsDynamicUi.sln --configuration Release --warnaserror -p:EnableWindowsTargeting=true
```

これはWindows向けのコンパイル確認です。macOS／LinuxでこのWinForms画面やSmokeTestsを実行できる、という意味ではありません。

自動検証はVisual Studioのデザイナー操作や、文字の欠け・重なりを目視確認するものではありません。対象のWindows環境で、7画面（MainFormと6つのView）のデザイナーを開けること、キーボードのTab移動、最小サイズで右端・下端までスクロールできること、DPI 100%／150%／200%で日本語表示が収まることを別途確認してください。サンプルは`AutoScaleMode.Font`と`PerMonitorV2`を指定していますが、自由配置における文字収まりをすべての環境で保証するものではありません。

## 参考

- [Microsoft Learn：Visual StudioでWinFormsアプリを作成する](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/get-started/create-app-visual-studio)
- [Microsoft Learn：.NET Desktop SDKのプロジェクト設定](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props-desktop)
- [Microsoft Learn：Windows以外からのビルドとEnableWindowsTargeting](https://learn.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1100)
