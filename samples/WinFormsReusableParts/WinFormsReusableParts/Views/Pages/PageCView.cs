using WinFormsReusableParts.Contracts;

namespace WinFormsReusableParts.Views.Pages;

public partial class PageCView : UserControl, ICheckedTextPage
{
    public PageCView()
    {
        InitializeComponent();
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        return [.. partW.GetCheckedTexts(), .. partX.GetCheckedTexts()];
    }
}
