using WinFormsReusableParts.Contracts;

namespace WinFormsReusableParts.Views.Parts;

public partial class PartWControl : UserControl, ICheckedTextSource
{
    public PartWControl()
    {
        InitializeComponent();
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        return checkBoxShowGuides.Checked ? [checkBoxShowGuides.Text] : [];
    }
}
