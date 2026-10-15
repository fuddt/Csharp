# C# WinForms：選択した点を右クリックで操作する機能の設計 ― MVCと責務分離

## 背景と課題

WinFormsの描画エリアに多数の「点」が表示されているとする。操作の流れは次のとおり。

1. メイン画面で点を**左クリックして選択**する。
2. **右クリック**するとコンテキストメニューが表示される。
3. メニューの「編集」「削除」などから、**すでに選択されている点**を操作する。

メニュー機能が増える見込みなので、右クリック関連のコードをメイン画面から分離したい。しかし、右クリック用クラスがメイン画面のModelに直接触れるようにすると、責務が曖昧になりそうだ。クリック座標や選択対象の情報をどこで管理し、どのように渡すべきだろうか。

この記事は、この設計問題についての検討メモである。**既存アプリの実際の選択状態の保存場所は未確認**なので、以下は確定仕様ではなく設計例として示す。

## 結論

**「選択状態の所有者」と「選択された点への操作を提供する右クリック機能」を分ける。**

- 左クリックで点を見つけ、選択するのはメイン画面側の責務。
- 選択中の点IDなどは、メイン画面のModel、あるいは選択状態専用のクラスで一元管理する。
- 右クリック発生時、メイン画面は**選択対象IDとメニュー表示位置**を右クリック機能の公開窓口に渡す。
- 右クリック側は渡された対象を検証し、メニューを表示して、選ばれた操作を実行する。
- 右クリック側が独自の「もう一つの正本」として選択状態を管理しない。

まずは**必要な情報をメソッドの引数で渡す**設計を推奨する。常時、複数機能から選択状態を参照する必要が出てきた場合に限り、共有の選択状態サービスを検討すればよい。

## MVCに関する整理

「ViewからModelへ直接アクセスしてはいけない」というのは、すべてのMVCに共通する厳密な禁止規則ではない。古典的なMVCではViewがModelを直接参照し、表示内容を取得する構成がある。Web MVCなど、フレームワークにより役割分担も異なる。

一方、WinFormsの実装規約として次のように決めるのは合理的である。

| 操作 | 推奨方針 |
| --- | --- |
| ViewがModelの値を読む | 古典的MVCでは許容される |
| ViewがModelの業務データを直接変更する | 原則としてControllerなどに委ねる |
| Viewが削除可否などの業務判断を行う | 避ける |
| Viewが右クリック操作をControllerへ通知する | 適切 |
| メイン画面が右クリック専用Modelの内部状態を書き換える | 避ける |

上記の「原則」は**今回採用する設計方針**であり、MVCの普遍的な文法規則ではない。また、Modelをまったく参照しない「Passive View」を徹底したいなら、MVCよりMVPと呼ぶ方が正確な場合もある。

## 設計イメージ

\`\`\`mermaid
flowchart TD
    User["利用者"]
    MainView["MainForm / 描画エリア"]
    MainController["MainController"]
    Selection["SelectionState：選択中の点IDを保持"]
    MenuAPI["IRightClickMenu：右クリック機能の公開窓口"]
    MenuController["RightClickController"]
    MenuView["RightClickView：ContextMenuStrip"]
    Points["IPointService / 点データの正本"]

    User -->|"① 左クリック"| MainView
    MainView -->|"位置を渡して選択"| MainController
    MainController -->|"ヒットテスト"| Points
    MainController -->|"選択状態を更新"| Selection
    User -->|"② 右クリック"| MainView
    MainView -->|"選択中IDを取得"| MainController
    MainController -->|"現在の選択を参照"| Selection
    MainView -->|"③ Show(選択ID, メニュー位置)"| MenuAPI
    MenuAPI --> MenuController
    MenuController -->|"存在や操作可否を確認"| Points
    MenuController -->|"④ 表示"| MenuView
    MenuView -->|"⑤ コマンド選択を通知"| MenuController
    MenuController -->|"⑥ 編集・削除など"| Points
\`\`\`

この図でMainFormが知る必要があるのは、メイン画面用Controllerと\`IRightClickMenu\`だけ。右クリック内部のView/Controller/Modelの具体型をMainFormへ公開する必要はない。

### なぜ「右クリックのViewだけを公開」しないのか

Viewだけを窓口にする構成も不可能ではない。しかし、外部からの要求を受け付ける責務と表示の責務がViewに混ざる。そこで、\`IRightClickMenu\`のような**機能単位のインターフェース**を公開し、内部でControllerとViewを協調させる。

重要なのは「各機能に必ずMVCの3クラスを1組ずつ作る」ことではない。**点のデータの正本は共通**とし、右クリック固有の表示や処理を分離することの方が大切である。

## C#の実装例（WinForms）

以下は設計上の接続を示す最小例。実際の点描画・データ保存処理は既存システムに合わせて実装する。

### 1. メイン側の選択状態と点データへのアクセス

\`\`\`csharp
using System;
using System.Drawing;
using System.Windows.Forms;

// 点データの検索・操作を提供する抽象化。
// 実際の保存先や描画エンジンとは切り離す。
public interface IPointService
{
    int? FindPointAt(Point clientPosition);
    bool Exists(int pointId);
    void Delete(int pointId);
}

// 「現在選択されている点」の正本。
// この例ではメイン側が管理し、外から勝手に書き換えられないようにする。
public sealed class SelectionState
{
    public int? SelectedPointId { get; private set; }

    public void Select(int? pointId)
    {
        SelectedPointId = pointId;
    }

    public void ClearIfSelected(int pointId)
    {
        if (SelectedPointId == pointId)
            SelectedPointId = null;
    }
}

public sealed class MainController
{
    private readonly IPointService _points;
    private readonly SelectionState _selection;

    public MainController(IPointService points, SelectionState selection)
    {
        _points = points;
        _selection = selection;
    }

    public int? SelectedPointId
    {
        get { return _selection.SelectedPointId; }
    }

    public void SelectAt(Point clientPosition)
    {
        // 描画エリア上のクリック位置から対象点を検索する。
        // 存在しなければ選択解除（実際の仕様に合わせて調整）。
        _selection.Select(_points.FindPointAt(clientPosition));
    }
}
\`\`\`

### 2. 右クリック機能の外部公開インターフェース

\`\`\`csharp
public interface IRightClickMenu
{
    // owner: メニュー表示先の描画コントロール
    // menuPosition: owner内の座標
    // selectedPointId: 左クリックで選択済みの点ID
    void Show(Control owner, Point menuPosition, int? selectedPointId);

    // 点の変更後、描画を更新してほしいことを外部へ通知する。
    event EventHandler PointsChanged;
}
\`\`\`

このAPIなら、MainFormは右クリック内部の\`RightClickModel\`や\`RightClickView\`を直接参照しない。

### 3. メイン画面は「イベントの転送」に徹する

\`\`\`csharp
public partial class MainForm : Form
{
    private readonly MainController _mainController;
    private readonly IRightClickMenu _rightClickMenu;

    public MainForm(MainController mainController, IRightClickMenu rightClickMenu)
    {
        InitializeComponent();

        _mainController = mainController;
        _rightClickMenu = rightClickMenu;

        // 操作で点が変化したら、描画エリアを再描画する。
        _rightClickMenu.PointsChanged += (sender, args) =>
            drawingArea.Invalidate();

        // イベントはDesigner側ですでに接続されているなら二重登録しない。
        drawingArea.MouseUp += DrawingArea_MouseUp;
    }

    private void DrawingArea_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            // 点の選択はメイン側のControllerへ。
            _mainController.SelectAt(e.Location);
            drawingArea.Invalidate();
        }
        else if (e.Button == MouseButtons.Right)
        {
            // 選択済みの点IDと、メニューを開く位置は別情報。
            _rightClickMenu.Show(
                drawingArea,
                e.Location,
                _mainController.SelectedPointId);
        }
    }
}
\`\`\`

**ここが設計上の要点**。右クリック位置の点を新たに選び直しているわけではない。左クリックによって選択済みの点IDを渡している。右クリック位置はあくまで**メニューを表示するための座標**として使う。

### 4. 右クリックViewは表示と操作通知に限定する

\`\`\`csharp
public sealed class RightClickView
{
    private readonly ContextMenuStrip _menu = new ContextMenuStrip();

    // 「削除が選ばれた」という事実だけを通知する。
    public event EventHandler DeleteRequested;

    public RightClickView()
    {
        ToolStripMenuItem deleteItem = new ToolStripMenuItem("削除");

        deleteItem.Click += (sender, args) =>
        {
            EventHandler handler = DeleteRequested;
            if (handler != null)
                handler(this, EventArgs.Empty);
        };

        _menu.Items.Add(deleteItem);
    }

    public void Show(Control owner, Point clientPosition)
    {
        // 表示位置は owner のクライアント座標系。
        _menu.Show(owner, clientPosition);
    }
}
\`\`\`

### 5. 右クリックControllerが対象を検証して操作する

\`\`\`csharp
public sealed class RightClickController : IRightClickMenu
{
    private readonly IPointService _points;
    private readonly SelectionState _selection;
    private readonly RightClickView _view;

    // メニューを開いた時点の操作対象を一時的に保持する。
    // これは「選択状態の正本」ではない。
    private int? _menuTargetPointId;

    public event EventHandler PointsChanged;

    public RightClickController(
        IPointService points,
        SelectionState selection,
        RightClickView view)
    {
        _points = points;
        _selection = selection;
        _view = view;

        _view.DeleteRequested += OnDeleteRequested;
    }

    public void Show(Control owner, Point menuPosition, int? selectedPointId)
    {
        // 選択がなければメニューは表示しない。
        _menuTargetPointId = null;

        if (!selectedPointId.HasValue)
            return;

        // 対象点がすでに削除されている場合も操作しない。
        if (!_points.Exists(selectedPointId.Value))
            return;

        _menuTargetPointId = selectedPointId.Value;
        _view.Show(owner, menuPosition);
    }

    private void OnDeleteRequested(object sender, EventArgs e)
    {
        if (!_menuTargetPointId.HasValue)
            return;

        int targetId = _menuTargetPointId.Value;
        _menuTargetPointId = null;

        // メニュー表示中に点が消えた場合への再チェック。
        if (!_points.Exists(targetId))
            return;

        _points.Delete(targetId);
        _selection.ClearIfSelected(targetId);

        EventHandler handler = PointsChanged;
        if (handler != null)
            handler(this, EventArgs.Empty);
    }
}
\`\`\`

\`IPointService\`の実装、Controller/Viewのインスタンス生成と依存注入、削除確認ダイアログ等は省略している。実運用では例外処理、イベント解除、操作後の整合性、同時更新、メニューが閉じられた場合の一時状態の扱いも検討する。

## 「選択IDを渡す方式」と「状態を共有する方式」

| 観点 | メソッド引数で選択IDを渡す | SelectionStateを右クリックControllerと共有 |
| --- | --- | --- |
| メイン側との結合 | 比較的小さい | 共通状態への依存が増える |
| データの受け渡し | 右クリック時のスナップショット | 現在の選択をいつでも参照 |
| 単体テスト | 入力値を与えやすい | 共有状態のセットアップが必要 |
| 適する状況 | 単発のメニュー表示・操作 | 複数の機能が選択変更を継続監視する |

このコード例では、**Showへの受け渡しは引数方式**、一方で**削除後に選択を解除するためControllerが共通のSelectionStateも参照する**折衷構成としている。

共有状態への依存をさらに減らしたいなら、右クリック側のControllerは\`SelectionState\`を持たずに「削除完了（点ID）」イベントだけを発行し、メイン側Controllerに選択解除を任せてもよい。

## 実装時に見落としやすい点

1. **左クリック座標と右クリック座標は役割が違う。** 左クリック座標は選択対象を特定する入力。右クリック座標はメニュー表示位置。両者を同じ「対象点」として扱わない。
2. **座標系を統一する。** \`MouseEventArgs.Location\`はイベント元コントロールのクライアント座標。ズーム・スクロール・座標変換後の図形座標を使う場合は変換場所を決める。
3. **メニュー実行時にも対象の有効性を検証する。** 表示からコマンド実行までの間に対象点が変更・削除される可能性がある。表示時の\`Exists\`だけでは十分でない。
4. **右クリック機能内に点データの別コピーを作らない。** 点データの正本を複数作ると不整合の原因になる。
5. **Modelを機能ごとに無理に分割しない。** 点を操作するメニューのために、点データ自体を複製した\`RightClickModel\`を作る必要はない。右クリック固有の状態や規則が必要になったときだけ専用Modelを追加すればよい。
6. **選択変更時のポリシーを決める。** メニューを表示した後で別の点が選択された場合、開いた時点の対象を操作するのか、最新の選択へ追従するのかを明文化する。上記サンプルは「開いた時点の対象」で動く。
7. **右クリック対象の判定ルールを明文化する。** 右クリックした場所の点を選択するUIなのか、既存の左クリック選択を保持するUIなのかで振る舞いが変わる。この記事は後者を前提とする。

## 今後確認したいこと

既存アプリで選択状態がどこに保存されているか（\`MainForm\`、メイン側Controller、Model、点オブジェクト自身の選択フラグ等）は未確認である。そこを特定してから、既存の責務を維持する最小限の変更で接続することが望ましい。

最終的な指針は、**「点の選択」はメイン側、「選択済みの点に対するメニュー操作」は右クリック側、点データの正本は共通**という分担である。MVCという名称を形式的に揃えることより、データの所有者と変更経路を明確にすることを優先する。
