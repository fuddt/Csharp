using WinFormsReusableParts.Contracts;
using WinFormsReusableParts.Controllers;
using WinFormsReusableParts.Models;

namespace WinFormsReusableParts.Views.Pages;

public partial class PageEView : UserControl, ICheckedTextPage
{
    public PageEView()
    {
        InitializeComponent();
    }

    internal PageEView(IReadOnlyModeModel model, ModeController controller) : this()
    {
        // 初期値を表示してから通知を接続する。復元は変更操作として扱わない。
        textBoxLastEInput.Text = model.LastEInput;
        textBoxLastEInput.TextChanged += (_, _) => controller.ChangeEInput(textBoxLastEInput.Text);
    }

    public IReadOnlyList<string> GetCheckedTexts()
    {
        return partX.GetCheckedTexts();
    }
}
