using WinFormsReusableParts.Contracts;
using WinFormsReusableParts.Controllers;
using WinFormsReusableParts.Models;
using WinFormsReusableParts.Views.Pages;

namespace WinFormsReusableParts.Forms;

public partial class ModeSelectForm : Form
{
    private readonly IReadOnlyModeModel readOnlyModel;
    private readonly ModeController controller;
    private UserControl? currentPage;
    private RadioButton? currentMode;

    public ModeSelectForm()
    {
        InitializeComponent();

        // このダイアログを閉じるまで、どのページも同じModelを使う。
        var model = new ModeModel();
        readOnlyModel = model;
        controller = new ModeController(model);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!DesignMode)
        {
            var selected = groupBoxModes.Controls.OfType<RadioButton>()
                .FirstOrDefault(button => button.Checked) ?? radioButtonA;
            selected.Checked = true;
            ShowPage(selected);
        }
    }

    private void ModeRadioButton_CheckedChanged(object? sender, EventArgs e)
    {
        // 初期化中の通知と、選択が外れた側の通知は処理しない。
        if (currentMode is not null && sender is RadioButton { Checked: true } selected)
        {
            ShowPage(selected);
        }
    }

    private void ShowPage(RadioButton selected)
    {
        if (selected == currentMode)
        {
            return;
        }

        panelPageHost.SuspendLayout();
        try
        {
            UserControl? nextPage = null;
            try
            {
                // 新しいページの生成・追加が成功するまで、現在のページを残す。
                nextPage = CreatePage(selected.Tag as string);
                nextPage.Dock = DockStyle.Fill;
                panelPageHost.Controls.Add(nextPage);
            }
            catch (Exception error)
            {
                // 追加の途中で失敗した場合も、Disposeで候補を親から外す。
                nextPage?.Dispose();
                if (currentMode is null)
                {
                    throw;
                }

                // 選択を戻す通知は冒頭の同一モード判定で止まる。
                currentMode.Checked = true;
                textBoxResult.Text = $"ページを開けませんでした。{Environment.NewLine}{error.Message}";
                return;
            }

            var previousPage = currentPage;
            currentPage = nextPage;
            currentMode = selected;
            if (previousPage is not null)
            {
                panelPageHost.Controls.Remove(previousPage);
                previousPage.Dispose();
            }

            textBoxResult.Clear();
        }
        finally
        {
            panelPageHost.ResumeLayout(performLayout: true);
        }
    }

    private UserControl CreatePage(string? mode)
    {
        return mode switch
        {
            "A" => new PageAView(),
            "B" => new PageBView(),
            "C" => new PageCView(),
            "D" => new PageDView(),
            "E" => new PageEView(readOnlyModel, controller),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, "未登録のモードです。")
        };
    }

    private void ButtonGetCheckedTexts_Click(object? sender, EventArgs e)
    {
        if (currentPage is ICheckedTextPage page)
        {
            var texts = page.GetCheckedTexts();
            textBoxResult.Text = texts.Count == 0
                ? "チェックされた項目はありません。"
                : string.Join(Environment.NewLine, texts);
        }
    }
}
