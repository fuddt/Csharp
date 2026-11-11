namespace WinFormsDynamicUi.Views;

public partial class ModeFView : UserControl
{
    public ModeFView()
    {
        InitializeComponent();
        comboBoxColor.SelectedIndex = 0;
    }

    private void ButtonApplyColor_Click(object? sender, EventArgs e)
    {
        panelSwatch.BackColor = comboBoxColor.SelectedIndex switch
        {
            1 => Color.SeaGreen,
            2 => Color.IndianRed,
            _ => Color.SteelBlue
        };
        labelColor.Text = $"選択中: {comboBoxColor.Text}";
    }

    private void ButtonApplySize_Click(object? sender, EventArgs e)
    {
        panelSwatch.Size = new Size((int)numericWidth.Value, (int)numericHeight.Value);
    }
}
