using WinFormsDynamicUi.Views;

namespace WinFormsDynamicUi;

public partial class MainForm : Form
{
    private UserControl? currentView;
    private int viewCreationCount;

    public MainForm()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        // デザイナーでは共通領域だけを編集する。可変UIの生成は実行時に行う。
        if (!DesignMode)
        {
            ShowMode("A");
        }
    }

    private void ModeRadioButton_CheckedChanged(object? sender, EventArgs e)
    {
        // 切り替えでは「外れた側」と「選ばれた側」の両方のイベントが発生する。
        if (sender is RadioButton { Checked: true, Tag: string mode })
        {
            ShowMode(mode);
        }
    }

    private void ShowMode(string mode)
    {
        panelCenter.SuspendLayout();
        try
        {
            if (currentView is not null)
            {
                panelCenter.Controls.Remove(currentView);
                // Controls.Clear/Removeだけでは破棄されないので、明示的にDisposeする。
                currentView.Dispose();
                currentView = null;
            }

            // キャッシュせず、選択されたモードの画面を毎回新しく生成する。
            currentView = mode switch
            {
                "A" => new ModeAView(),
                "B" => new ModeBView(),
                "C" => new ModeCView(),
                "D" => new ModeDView(),
                "E" => new ModeEView(),
                "F" => new ModeFView(),
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, "未対応のモードです。")
            };

            currentView.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(currentView);
            viewCreationCount++;
            labelCurrentMode.Text = $"現在: {mode}  /  生成回数: {viewCreationCount}  /  モード内の入力は切り替えると初期化されます";
        }
        finally
        {
            panelCenter.ResumeLayout(true);
        }
        // フォーム終了時は、panelCenterが所有する最後のViewも一緒に破棄される。
    }

    private void ButtonClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
