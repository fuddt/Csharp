using WinFormsReusableParts.Contracts;

namespace WinFormsReusableParts.Views.Parts;

public partial class PartYControl : UserControl, ICheckedTextSource
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
