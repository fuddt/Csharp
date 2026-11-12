using WinFormsReusableParts.Contracts;

namespace WinFormsReusableParts.Views.Parts;

public partial class PartZControl : UserControl, ICheckedTextSource
{
    public PartZControl()
    {
        InitializeComponent();
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        return checkBoxIncludeTime.Checked ? [checkBoxIncludeTime.Text] : [];
    }
}
