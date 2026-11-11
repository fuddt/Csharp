namespace WinFormsDynamicUi.Views;

public partial class ModeCView : UserControl
{
    public ModeCView()
    {
        InitializeComponent();
    }

    private void ButtonApply_Click(object? sender, EventArgs e)
    {
        labelCoordinates.Text = $"X = {numericX.Value:F1}, Y = {numericY.Value:F1}";
    }

    private void TrackBarAngle_ValueChanged(object? sender, EventArgs e)
    {
        labelAngle.Text = $"角度: {trackBarAngle.Value}°";
    }
}
