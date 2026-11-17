namespace WinFormsEscFocusReturn.Forms;

public partial class SmallToolForm : Form
{
    private readonly Form? _returnTarget;
    private int _actionCount;

    public SmallToolForm() : this(null)
    {
    }

    public SmallToolForm(Form? returnTarget)
    {
        _returnTarget = returnTarget;
        InitializeComponent();
        UpdateFocusLabel(isActive: false);
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        UpdateFocusLabel(isActive: true);
    }

    protected override void OnDeactivate(EventArgs e)
    {
        base.OnDeactivate(e);
        UpdateFocusLabel(isActive: false);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Escape)
        {
            ReturnFocusToMainForm();
            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ReturnFocusToMainForm()
    {
        // Show(this) で開かれた場合は Owner が設定されている。
        // Show()（Owner なし）で開かれた場合はコンストラクタで受け取った参照を使う。
        Form? target = Owner ?? _returnTarget;
        if (target is not null && !target.IsDisposed)
        {
            target.Activate();
        }
    }

    private void ButtonSubAction_Click(object? sender, EventArgs e)
    {
        _actionCount++;
        buttonSubAction.Text = $"操作テスト ({_actionCount}回)";
    }

    private void ButtonClose_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void UpdateFocusLabel(bool isActive)
    {
        if (isActive)
        {
            labelSmallStatus.Text = "状態：小さいForm がアクティブ";
            labelSmallStatus.BackColor = Color.FromArgb(227, 242, 253);
        }
        else
        {
            labelSmallStatus.Text = "状態：小さいForm は非アクティブ";
            labelSmallStatus.BackColor = Color.FromArgb(245, 245, 245);
        }
    }
}
