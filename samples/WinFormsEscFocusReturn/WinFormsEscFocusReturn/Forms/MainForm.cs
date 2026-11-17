namespace WinFormsEscFocusReturn.Forms;

public partial class MainForm : Form
{
    private SmallToolForm? _smallForm;

    public MainForm()
    {
        InitializeComponent();
        UpdateFocusStatus(isActive: false);
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        UpdateFocusStatus(isActive: true);
    }

    protected override void OnDeactivate(EventArgs e)
    {
        base.OnDeactivate(e);
        UpdateFocusStatus(isActive: false);
    }

    private void ButtonOpenSmallForm_Click(object? sender, EventArgs e)
    {
        // すでに開いている場合は二重に生成せず、既存の小さいFormを前面に出す。
        if (_smallForm is { IsDisposed: false })
        {
            _smallForm.Activate();
            return;
        }

        // Show()（Owner なし）を選んだ場合でも戻れるように、参照を渡せるコンストラクタを使う。
        // Show(this)（Owner あり）のときは Owner プロパティだけで戻れる。
        var smallForm = new SmallToolForm(returnTarget: this)
        {
            StartPosition = FormStartPosition.Manual,
            Location = new Point(Left + 360, Top + 170)
        };

        smallForm.FormClosed += (_, _) =>
        {
            _smallForm = null;
            checkBoxUseOwner.Enabled = true;
        };

        _smallForm = smallForm;
        checkBoxUseOwner.Enabled = false;

        if (checkBoxUseOwner.Checked)
        {
            // Owner を指定してモードレス表示：
            // メインFormへフォーカスが移っても、小さいFormはメインFormより手前に残る。
            smallForm.Show(this);
        }
        else
        {
            // Owner を指定せずモードレス表示：
            // メインFormへフォーカスが移ると、Zオーダー上はメインFormが前面になる。
            smallForm.Show();
        }
    }

    private void UpdateFocusStatus(bool isActive)
    {
        if (isActive)
        {
            labelFocusStatus.Text = "状態：メインForm がアクティブ（フォーカスあり）";
            labelFocusStatus.BackColor = Color.FromArgb(232, 245, 233);
        }
        else
        {
            labelFocusStatus.Text = "状態：メインForm は非アクティブ";
            labelFocusStatus.BackColor = Color.FromArgb(245, 245, 245);
        }
    }
}
