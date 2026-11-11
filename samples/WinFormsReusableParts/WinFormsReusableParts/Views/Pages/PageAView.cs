using WinFormsReusableParts.Contracts;

namespace WinFormsReusableParts.Views.Pages;

public partial class PageAView : UserControl, ICheckedTextPage
{
    public PageAView()
    {
        InitializeComponent();
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        return [.. partX.GetCheckedTexts(), .. partY.GetCheckedTexts()];
    }
}
