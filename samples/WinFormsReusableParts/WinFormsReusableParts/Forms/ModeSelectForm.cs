using WinFormsReusableParts.Contracts;
using WinFormsReusableParts.Views.Parts;

namespace WinFormsReusableParts.Forms;

public partial class ModeSelectForm : Form
{
    private readonly Control[] allParts;
    private string? currentMode;

    public ModeSelectForm()
    {
        InitializeComponent();
        allParts = [partX, partY, partZ, partW, partE];
    }

    /// <summary>
    /// ウィンドウ全体を合成バッファで描画することで、コントロールの配置変更や切り替え時のちらつきを完全に抑止します。
    /// </summary>
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
            return cp;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!DesignMode)
        {
            var selected = groupBoxModes.Controls.OfType<RadioButton>()
                .FirstOrDefault(button => button.Checked) ?? radioButtonA;
            selected.Checked = true;
            ApplyMode(selected.Tag as string ?? "A");
        }
    }

    private void ModeRadioButton_CheckedChanged(object? sender, EventArgs e)
    {
        // 選択が外れた側の通知はスキップし、ONになった側だけを処理する
        if (sender is RadioButton { Checked: true } selected)
        {
            ApplyMode(selected.Tag as string ?? "A");
        }
    }

    private Control[] GetControlsForMode(string mode) => mode switch
    {
        "A" => [partX, partY],
        "B" => [partX, partZ],
        "C" => [partW, partX], // CはWが上、Xが下
        "D" => [partY, partZ],
        "E" => [partE, partX], // EはTextBoxが上、Xが下
        _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, "未登録のモードです。")
    };

    private void ApplyMode(string mode)
    {
        if (mode == currentMode)
        {
            return;
        }

        var activeControls = GetControlsForMode(mode);

        panelPageHost.SuspendLayout();
        try
        {
            // 1. すべての部品を一旦非表示にする（破棄はせず、状態も保持）
            foreach (var part in allParts)
            {
                part.Visible = false;
            }

            // 2. このモードに必要な部品だけを、指定された順序で上から隙間なく配置して表示する
            int top = 16;
            foreach (var control in activeControls)
            {
                control.Location = new Point(16, top);
                control.Visible = true;
                top += control.Height + 12;
            }

            currentMode = mode;
            textBoxResult.Clear();
        }
        finally
        {
            panelPageHost.ResumeLayout(performLayout: true);
        }
    }

    private void ButtonGetCheckedTexts_Click(object? sender, EventArgs e)
    {
        if (currentMode is null)
        {
            return;
        }

        var activeControls = GetControlsForMode(currentMode);
        var texts = new List<string>();

        // 現在表示されている部品の中から、チェック項目を持つものだけを順次集約
        foreach (var control in activeControls)
        {
            if (control is ICheckedTextSource source)
            {
                texts.AddRange(source.GetCheckedTexts());
            }
        }

        textBoxResult.Text = texts.Count == 0
            ? "チェックされた項目はありません。"
            : string.Join(Environment.NewLine, texts);
    }
}
