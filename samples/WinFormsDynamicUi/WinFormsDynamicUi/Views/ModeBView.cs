namespace WinFormsDynamicUi.Views;

public partial class ModeBView : UserControl
{
    public ModeBView()
    {
        InitializeComponent();
    }

    private void ButtonFilter_Click(object? sender, EventArgs e)
    {
        (string Name, int Value)[] samples = [("センサーA", 25), ("センサーB", 55), ("センサーC", 80)];
        listBoxResults.Items.Clear();

        foreach (var sample in samples)
        {
            bool matches = radioButtonAtLeast.Checked
                ? sample.Value >= numericThreshold.Value
                : sample.Value <= numericThreshold.Value;
            if (matches)
            {
                listBoxResults.Items.Add($"{sample.Name}: {sample.Value}");
            }
        }

        labelResultCount.Text = $"該当: {listBoxResults.Items.Count} 件";
    }
}
