namespace WinFormsDynamicUi.Views;

public partial class ModeAView : UserControl
{
    public ModeAView()
    {
        InitializeComponent();
        comboBoxCategory.SelectedIndex = 0;
    }

    private void ButtonPreview_Click(object? sender, EventArgs e)
    {
        labelPreview.Text = $"{textBoxName.Text} / {numericQuantity.Value} 個 / {comboBoxCategory.Text}";
    }
}
