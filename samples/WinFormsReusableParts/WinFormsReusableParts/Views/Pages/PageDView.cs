using WinFormsReusableParts.Contracts;

namespace WinFormsReusableParts.Views.Pages;

public partial class PageDView : UserControl, ICheckedTextPage
{
    public PageDView()
    {
        InitializeComponent();
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        return [.. partY.GetCheckedTexts(), .. partZ.GetCheckedTexts()];
    }
}
