namespace WinFormsReusableParts.Views.Parts;

public partial class PartXControl : UserControl
{
    public PartXControl()
    {
        InitializeComponent();
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        var texts = new List<string>();
        if (checkBoxShowPreview.Checked)
        {
            texts.Add(checkBoxShowPreview.Text);
        }

        if (checkBoxUseActualSize.Checked)
        {
            texts.Add(checkBoxUseActualSize.Text);
        }

        return texts;
    }
}
