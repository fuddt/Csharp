namespace WinFormsReusableParts.Views.Parts;

public partial class PartEControl : UserControl
{
    public PartEControl()
    {
        InitializeComponent();
    }

    /// <summary>入力されたテキストを取得または設定します。</summary>
    public string InputText
    {
        get => textBoxLastEInput.Text;
        set => textBoxLastEInput.Text = value;
    }
}
