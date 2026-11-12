# WinForms：ちらつきのない可変UIと部品再利用（スロット可視性切替方式）

メイン画面の「設定画面を開く」から、5つのモード（A〜E）をラジオボタンで切り替えられる小型ダイアログの学習用サンプルです。
各モードで一部の部品（プレビュー部品Xなど）を共有しながら、**切り替え時の画面のちらつき（Flicker）を完全にゼロにし、現在表示されている部品のチェック項目だけを正確に取得**できます。

---

## 最初に動かす

Windows環境、Visual Studio（「.NET デスクトップ開発」ワークロード）、.NET 10 SDKに対応しています（ターゲットフレームワーク: `net10.0-windows`）。

1. [WinFormsReusableParts.sln](WinFormsReusableParts.sln) をVisual Studioで開きます。
2. `WinFormsReusableParts` をスタートアッププロジェクトに設定し、F5で起動します。
3. 「設定画面を開く」を押すと、モードAが選択された小型ダイアログが開きます。
4. Aで「プレビューを表示する」にチェックを入れ、Bへ切り替えます。
   - **画面が全くチカチカ（ちらつき）せず、一瞬で切り替わります**。
   - Bでも「プレビューを表示する」のチェックがそのまま残っています（共通設定としての保持）。
5. Bで「取得」を押すと、Bに表示されている項目（XとZ）だけが集約され、非表示のA専用項目（Y）は混入しません。
6. EでTextBoxに文字を入力し、別のモードへ移動してからEに戻ると、入力した文字がそのまま残っています。

Windowsのターミナルからビルド・実行する場合：

```powershell
dotnet build WinFormsReusableParts.sln --configuration Release --warnaserror
dotnet run --project WinFormsReusableParts/WinFormsReusableParts.csproj
dotnet run --project SmokeTests/SmokeTests.csproj --configuration Release --no-build
```

---

## モードごとの部品構成

| モード | 上段の部品 | 下段の部品 |
| :--- | :--- | :--- |
| **A** | **X**（プレビュー） | **Y**（入力確認） |
| **B** | **X**（プレビュー） | **Z**（出力設定） |
| **C** | **W**（補助表示） | **X**（プレビュー） ※Wが上、Xが下 |
| **D** | **Y**（入力確認） | **Z**（出力設定） |
| **E** | **E**（メモ入力TextBox） | **X**（プレビュー） ※TextBoxが上、Xが下 |

- **X（プレビュー）**: 「プレビューを表示する」「原寸で表示する」
- **Y（入力確認）**: 「入力値を検証する」
- **Z（出力設定）**: 「出力に時刻を含める」
- **W（補助表示）**: 「補助ガイドを表示する」
- **E（メモ入力）**: 自由入力可能なTextBox（デモ用の仮仕様）

---

## なぜ「画面の破棄・再生成」をやめ、「部品常駐＋Visible切り替え」にしたのか？

### 1. 画面再生成（Dispose/new）方式で生じた3つの壁
当初は「モード切り替えのたびに旧画面を破棄（Dispose）し、新画面を `new` して中央パネルに差し替える」という設計を検討していました。しかし、実際に動かしてみると以下の深刻な問題が発生しました：

1. **激しい画面のちらつき（Flicker）**
   - コントロールの `Remove` → `Dispose` → `Add` の瞬間に親パネルの背景消去（白抜け）が走り、子部品が順繰りに再描画されるため、ラジオボタンを押すたびに画面全体がチカチカと点滅する。
2. **同じ部品なのに位置が移動する違和感**
   - モードによってX部品が上段にあったり下段にあったり、ページごとに別々の座標に飛び跳ねるため、利用者の目線が迷子になる。
3. **入力・チェック状態が毎回消えるストレス**
   - コントロールを作り直すため、「さっきAでチェックしたはずの項目が、Bに行って戻ったらリセットされている」という挙動になり、直感的な操作感を損ねる。

### 2. 「部品常駐＋Visible切り替え（スロット固定方式）」による解決
そこで本サンプルでは、**中央パネルにあらかじめ全部品（X, Y, Z, W, E）を配置しておき、モードに応じて表示（`Visible = true`）と非表示（`Visible = false`）を切り替える方式**を採用しました。

- **ちらつきゼロ**: コントロールの破棄・生成が一切走らないため、切り替えが一瞬で完了。
- **視線の安定**: X部品などの定位置がブレず、自然な操作感を実現。
- **状態の自然な保持**: コントロールが生存し続けるため、Aで付けたチェックはBやCでもそのまま残り、Eのテキストも消えない。
- **隙間なしの自動上詰め**: 非表示になった部品のスペースは、下に続く部品がスッと上へ詰めるため、穴あきにならず美しいレイアウトを維持。

---

## ちらつきを完全に消す「3重の防壁」

WinFormsで可変UIを作る際、ちらつきを防ぐために本サンプルでは以下の3重の対策を施しています。

1. **コントロールを再生成しない（常駐方式）**
   - UIオブジェクトの生存期間をダイアログ全体に合わせることで、破棄・追加によるWindows内部メッセージ（WM_DESTROY / WM_CREATE）の嵐を避けます。
2. **`SuspendLayout()` と `ResumeLayout(true)`**
   - コントロールの `Visible` や `Location` を更新する間、一時的に親パネルの描画計算を停止し、全配置が整った瞬間に一括で再計算します。
3. **`WS_EX_COMPOSITED`（合成ダブルバッファリング）**
   - `ModeSelectForm` の `CreateParams` に拡張ウィンドウスタイル `0x02000000` を追加。OS レベルでフォーム全体（すべての子コントロールを含む）をメモリ上で合成描画してから一括転送するため、背景の白抜けが物理的に発生しません。

```csharp
// ModeSelectForm.cs 内の記述
protected override CreateParams CreateParams
{
    get
    {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
        return cp;
    }
}
```

---

## レイアウトの上詰めと配置順の仕組み

「非表示の部品があるなら、途中に空白ができるのではないか？」「CではWを上、Xを下にするにはどうするのか？」という疑問は、以下の小さなメソッドでシンプルに解決しています。

```csharp
// 1. モードごとに「表示する部品」と「並び順」を定義
private Control[] GetControlsForMode(string mode) => mode switch
{
    "A" => [partX, partY],
    "B" => [partX, partZ],
    "C" => [partW, partX], // CはWが上、Xが下！
    "D" => [partY, partZ],
    "E" => [partE, partX], // EはTextBoxが上、Xが下！
    _ => []
};

// 2. 指定された順序で上から隙間なく整列
private void ApplyMode(string mode)
{
    var activeControls = GetControlsForMode(mode);

    panelPageHost.SuspendLayout();
    try
    {
        // 全部品を一旦非表示
        foreach (var part in allParts)
        {
            part.Visible = false;
        }

        // 必要な部品だけを、指定順に上から詰めて配置・表示
        int top = 16;
        foreach (var control in activeControls)
        {
            control.Location = new Point(16, top);
            control.Visible = true;
            top += control.Height + 12; // 12pxの余白を空けて次へ
        }
    }
    finally
    {
        panelPageHost.ResumeLayout(performLayout: true);
    }
}
```

これにより、複雑なグリッドコンテナ（TableLayoutPanel等）に頼ることなく、シンプルな `Location` 指定だけで美しい上詰め配置を実現しています。

---

## 「取得」ボタンが現在ページの項目だけを集約する流れ

親フォームは個別のCheckBoxの名前（`checkBoxShowPreview` など）を一切知りません。

共通インターフェース `ICheckedTextSource` を定義し、各部品が自身のチェック済み文字列を返すようにしています。

```csharp
public interface ICheckedTextSource
{
    IReadOnlyList<string> GetCheckedTexts();
}
```

取得ボタンが押されたときは、**現在アクティブなコントロール配列（`activeControls`）だけを走査**します。

```csharp
private void ButtonGetCheckedTexts_Click(object? sender, EventArgs e)
{
    if (currentMode is null) return;

    var activeControls = GetControlsForMode(currentMode);
    var texts = new List<string>();

    foreach (var control in activeControls)
    {
        if (control is ICheckedTextSource source)
        {
            texts.AddRange(source.GetCheckedTexts());
        }
    }

    textBoxResult.Text = texts.Count == 0
        ? "チェックされた項目はありません。"
        : string.Join(Environment.NewLine, texts);
}
```

- モードB表示中は、`activeControls` に含まれる `partX` と `partZ` だけに問い合わせます。
- 過去にモードAでチェックを入れた `partY` は `activeControls` に含まれない（かつ `Visible = false`）ため、結果に混入することはありません。

---

## Visual Studioデザイナーでの編集手順

1. **各部品（UserControl）のデザイン編集**:
   - `Views/Parts/PartXControl.cs` などをダブルクリック、または右クリックして「デザイナーの表示」を開きます。
   - CheckBoxの追加、文言の修正、フォントや配置の変更を単独で行えます。ここでの修正は全モードに自動反映されます。
2. **ダイアログ全体の配置編集**:
   - `Forms/ModeSelectForm.cs` のデザイナーを開きます。
   - 中央パネル（`panelPageHost`）の中に、常駐する5つの部品が配置されています。
   - 部品を選択してプロパティウィンドウで基本サイズや初期位置を調整できます（実行時には `ApplyMode` によって選択モードの順序で整列されます）。

---

## クラス責務一覧

| クラス | 役割・責務 |
| :--- | :--- |
| `MainForm` | メイン画面。「設定画面を開く」ボタンからダイアログを `ShowDialog(this)` でモーダル起動し、完了後に破棄。 |
| `ModeSelectForm` | モード選択ダイアログ。ラジオボタンA〜E、中央パネル、取得結果欄を管理。モード切り替え時に部品の可視性と配置を制御。 |
| `ICheckedTextSource` | 部品が自身のチェック済み文字列を返すためのインターフェース契約。親フォームと部品の結合を最小化。 |
| `PartXControl` 〜 `PartWControl` | 各機能に応じたCheckBoxとGroupBoxを持つ共通UI部品。`ICheckedTextSource` を実装。 |
| `PartEControl` | メモ入力用のTextBoxを持つUI部品。 |

詳細な構成図やシーケンス図は、[クラス構成と処理の流れ](docs/architecture.md) をご覧ください。

---

## 本設計の利点とトレードオフ

### メリット
- **ちらつきゼロ**: 画面切り替えが驚くほど滑らかで、目に優しいUIを実現。
- **シンプルな実装**: 画面の破棄・生成や複雑なModelへの退避コードが不要になり、コード量が半減。
- **状態の直感的な保持**: 共通部品の設定がモード間で自然に維持される。
- **高い保守性**: 各部品は独立したUserControlとして単独でデザイナー編集・再利用可能。

### トレードオフ・留意点
- **部品数が多い場合**: もし可変部品が数十〜数百個に増えるような大規模画面では、全部品を最初からメモリ上に保持すると初期化負荷がかかる場合があります（5〜10個程度の画面部品であれば全く問題ありません）。
- **モードごとに同じ部品のチェック状態を完全に独立させたい場合**: もし「モードAのプレビューはON、モードBのプレビューはOFF」のように同じ部品で別々の値を持ちたい場合は、切り替えの瞬間にModelから値を出し入れする処理が追加で必要になります。
