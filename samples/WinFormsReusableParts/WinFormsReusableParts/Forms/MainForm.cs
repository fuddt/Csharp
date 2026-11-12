namespace WinFormsReusableParts.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void ButtonOpenSettings_Click(object? sender, EventArgs e)
    {
        using var dialog = new ModeSelectForm();
        dialog.ShowDialog(this);
    }
}
