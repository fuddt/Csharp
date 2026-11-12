namespace WinFormsReusableParts.Views.Parts;

public partial class PartYControl : UserControl
{
    public PartYControl()
    {
        InitializeComponent();
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        return checkBoxValidateInput.Checked ? [checkBoxValidateInput.Text] : [];
    }
}
