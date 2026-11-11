namespace WinFormsDynamicUi.Views;

public partial class ModeEView : UserControl
{
    public ModeEView()
    {
        InitializeComponent();
    }

    private void ButtonPreview_Click(object? sender, EventArgs e)
    {
        labelNotePreview.Text = checkBoxShowTitle.Checked
            ? $"メモの内容{Environment.NewLine}{Environment.NewLine}{richTextBoxNote.Text}"
            : richTextBoxNote.Text;
    }
}
