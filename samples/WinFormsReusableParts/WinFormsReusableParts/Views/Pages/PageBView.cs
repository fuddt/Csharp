using WinFormsReusableParts.Contracts;

namespace WinFormsReusableParts.Views.Pages;

public partial class PageBView : UserControl, ICheckedTextPage
{
    public PageBView()
    {
        InitializeComponent();
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        return [.. partX.GetCheckedTexts(), .. partZ.GetCheckedTexts()];
    }
}
