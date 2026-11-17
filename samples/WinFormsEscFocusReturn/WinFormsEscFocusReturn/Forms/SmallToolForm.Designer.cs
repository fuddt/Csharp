#nullable disable

namespace WinFormsEscFocusReturn.Forms;

partial class SmallToolForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        labelSmallStatus = new Label();
        labelGuide = new Label();
        textBoxSubInput = new TextBox();
        buttonSubAction = new Button();
        buttonClose = new Button();
        SuspendLayout();
        //
        // labelSmallStatus
        //
        labelSmallStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labelSmallStatus.BorderStyle = BorderStyle.FixedSingle;
        labelSmallStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        labelSmallStatus.Location = new Point(16, 14);
        labelSmallStatus.Name = "labelSmallStatus";
        labelSmallStatus.Padding = new Padding(6, 0, 6, 0);
        labelSmallStatus.Size = new Size(348, 28);
        labelSmallStatus.TabIndex = 0;
        labelSmallStatus.Text = "状態：";
        labelSmallStatus.TextAlign = ContentAlignment.MiddleLeft;
        //
        // labelGuide
        //
        labelGuide.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labelGuide.Location = new Point(16, 52);
        labelGuide.Name = "labelGuide";
        labelGuide.Size = new Size(348, 38);
        labelGuide.TabIndex = 1;
        labelGuide.Text = "Esc キーを押すと、この画面は閉じずに\r\nメインFormへフォーカスが移ります。";
        //
        // textBoxSubInput
        //
        textBoxSubInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxSubInput.Location = new Point(16, 100);
        textBoxSubInput.Name = "textBoxSubInput";
        textBoxSubInput.PlaceholderText = "入力中に Esc を押してもメインへ戻れます";
        textBoxSubInput.Size = new Size(348, 23);
        textBoxSubInput.TabIndex = 2;
        //
        // buttonSubAction
        //
        buttonSubAction.Location = new Point(16, 140);
        buttonSubAction.Name = "buttonSubAction";
        buttonSubAction.Size = new Size(168, 32);
        buttonSubAction.TabIndex = 3;
        buttonSubAction.Text = "操作テスト (0回)";
        buttonSubAction.UseVisualStyleBackColor = true;
        buttonSubAction.Click += ButtonSubAction_Click;
        //
        // buttonClose
        //
        buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonClose.Location = new Point(254, 198);
        buttonClose.Name = "buttonClose";
        buttonClose.Size = new Size(110, 32);
        buttonClose.TabIndex = 4;
        buttonClose.Text = "閉じる";
        buttonClose.UseVisualStyleBackColor = true;
        buttonClose.Click += ButtonClose_Click;
        //
        // SmallToolForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(380, 246);
        Controls.Add(labelSmallStatus);
        Controls.Add(labelGuide);
        Controls.Add(textBoxSubInput);
        Controls.Add(buttonSubAction);
        Controls.Add(buttonClose);
        FormBorderStyle = FormBorderStyle.SizableToolWindow;
        MinimumSize = new Size(340, 220);
        Name = "SmallToolForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "小さいForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelSmallStatus;
    private Label labelGuide;
    private TextBox textBoxSubInput;
    private Button buttonSubAction;
    private Button buttonClose;
}
