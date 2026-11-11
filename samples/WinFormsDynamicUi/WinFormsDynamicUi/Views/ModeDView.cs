namespace WinFormsDynamicUi.Views;

public partial class ModeDView : UserControl
{
    public ModeDView()
    {
        InitializeComponent();
        checkedListBoxJobs.SetItemChecked(0, true);
    }

    private void ButtonSelectAll_Click(object? sender, EventArgs e)
    {
        for (int index = 0; index < checkedListBoxJobs.Items.Count; index++)
        {
            checkedListBoxJobs.SetItemChecked(index, true);
        }
    }

    private void ButtonRun_Click(object? sender, EventArgs e)
    {
        // 実処理は行わず、選択された項目を表示するだけのUIサンプル。
        string[] jobs = checkedListBoxJobs.CheckedItems.Cast<string>().ToArray();
        textBoxOutput.Text = jobs.Length == 0
            ? "項目を選択してください。"
            : string.Join(Environment.NewLine, jobs.Select(job => $"[サンプル] {job}"));
    }
}
