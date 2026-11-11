#nullable disable

namespace WinFormsDynamicUi;

partial class MainForm
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

    #region Designer code

    private void InitializeComponent()
    {
        groupBoxTop = new GroupBox();
        radioButtonA = new RadioButton();
        radioButtonB = new RadioButton();
        radioButtonC = new RadioButton();
        radioButtonD = new RadioButton();
        radioButtonE = new RadioButton();
        radioButtonF = new RadioButton();
        labelModeHelp = new Label();
        groupBoxBottom = new GroupBox();
        labelCommonMemo = new Label();
        textBoxCommonMemo = new TextBox();
        buttonClose = new Button();
        labelCurrentMode = new Label();
        panelCenter = new Panel();
        groupBoxTop.SuspendLayout();
        groupBoxBottom.SuspendLayout();
        panelCenter.SuspendLayout();
        SuspendLayout();
        //
        // groupBoxTop
        //
        groupBoxTop.Controls.Add(radioButtonA);
        groupBoxTop.Controls.Add(radioButtonB);
        groupBoxTop.Controls.Add(radioButtonC);
        groupBoxTop.Controls.Add(radioButtonD);
        groupBoxTop.Controls.Add(radioButtonE);
        groupBoxTop.Controls.Add(radioButtonF);
        groupBoxTop.Controls.Add(labelModeHelp);
        groupBoxTop.Location = new Point(12, 12);
        groupBoxTop.Name = "groupBoxTop";
        groupBoxTop.Size = new Size(1016, 132);
        groupBoxTop.Text = "共通領域：モード選択";
        groupBoxTop.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxTop.Dock = DockStyle.Top;
        groupBoxTop.TabStop = false;
        groupBoxTop.TabIndex = 0;
        //
        // radioButtonA
        //
        radioButtonA.Location = new Point(24, 28);
        radioButtonA.Name = "radioButtonA";
        radioButtonA.Size = new Size(210, 26);
        radioButtonA.Text = "A: 基本入力";
        radioButtonA.Tag = "A";
        radioButtonA.Checked = true;
        radioButtonA.TabStop = true;
        radioButtonA.UseVisualStyleBackColor = true;
        radioButtonA.CheckedChanged += ModeRadioButton_CheckedChanged;
        radioButtonA.TabIndex = 0;
        //
        // radioButtonB
        //
        radioButtonB.Location = new Point(254, 28);
        radioButtonB.Name = "radioButtonB";
        radioButtonB.Size = new Size(210, 26);
        radioButtonB.Text = "B: 絞り込み";
        radioButtonB.Tag = "B";
        radioButtonB.Checked = false;
        radioButtonB.TabStop = false;
        radioButtonB.UseVisualStyleBackColor = true;
        radioButtonB.CheckedChanged += ModeRadioButton_CheckedChanged;
        radioButtonB.TabIndex = 1;
        //
        // radioButtonC
        //
        radioButtonC.Location = new Point(484, 28);
        radioButtonC.Name = "radioButtonC";
        radioButtonC.Size = new Size(210, 26);
        radioButtonC.Text = "C: 座標・角度";
        radioButtonC.Tag = "C";
        radioButtonC.Checked = false;
        radioButtonC.TabStop = false;
        radioButtonC.UseVisualStyleBackColor = true;
        radioButtonC.CheckedChanged += ModeRadioButton_CheckedChanged;
        radioButtonC.TabIndex = 2;
        //
        // radioButtonD
        //
        radioButtonD.Location = new Point(24, 60);
        radioButtonD.Name = "radioButtonD";
        radioButtonD.Size = new Size(210, 26);
        radioButtonD.Text = "D: 項目選択";
        radioButtonD.Tag = "D";
        radioButtonD.Checked = false;
        radioButtonD.TabStop = false;
        radioButtonD.UseVisualStyleBackColor = true;
        radioButtonD.CheckedChanged += ModeRadioButton_CheckedChanged;
        radioButtonD.TabIndex = 3;
        //
        // radioButtonE
        //
        radioButtonE.Location = new Point(254, 60);
        radioButtonE.Name = "radioButtonE";
        radioButtonE.Size = new Size(210, 26);
        radioButtonE.Text = "E: メモ編集";
        radioButtonE.Tag = "E";
        radioButtonE.Checked = false;
        radioButtonE.TabStop = false;
        radioButtonE.UseVisualStyleBackColor = true;
        radioButtonE.CheckedChanged += ModeRadioButton_CheckedChanged;
        radioButtonE.TabIndex = 4;
        //
        // radioButtonF
        //
        radioButtonF.Location = new Point(484, 60);
        radioButtonF.Name = "radioButtonF";
        radioButtonF.Size = new Size(210, 26);
        radioButtonF.Text = "F: 色・サイズ";
        radioButtonF.Tag = "F";
        radioButtonF.Checked = false;
        radioButtonF.TabStop = false;
        radioButtonF.UseVisualStyleBackColor = true;
        radioButtonF.CheckedChanged += ModeRadioButton_CheckedChanged;
        radioButtonF.TabIndex = 5;
        //
        // labelModeHelp
        //
        labelModeHelp.Location = new Point(24, 98);
        labelModeHelp.Name = "labelModeHelp";
        labelModeHelp.Size = new Size(968, 24);
        labelModeHelp.Text = "モードを選ぶと中央だけを作り直します。各Viewの配置はVisual Studioのデザイナーで編集できます。";
        labelModeHelp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labelModeHelp.AutoEllipsis = true;
        labelModeHelp.TabIndex = 6;
        //
        // groupBoxBottom
        //
        groupBoxBottom.Controls.Add(labelCommonMemo);
        groupBoxBottom.Controls.Add(textBoxCommonMemo);
        groupBoxBottom.Controls.Add(buttonClose);
        groupBoxBottom.Controls.Add(labelCurrentMode);
        groupBoxBottom.Location = new Point(12, 644);
        groupBoxBottom.Name = "groupBoxBottom";
        groupBoxBottom.Size = new Size(1016, 104);
        groupBoxBottom.Text = "共通領域：切り替えても残る入力";
        groupBoxBottom.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxBottom.Dock = DockStyle.Bottom;
        groupBoxBottom.TabStop = false;
        groupBoxBottom.TabIndex = 1;
        //
        // labelCommonMemo
        //
        labelCommonMemo.Location = new Point(24, 33);
        labelCommonMemo.Name = "labelCommonMemo";
        labelCommonMemo.Size = new Size(76, 22);
        labelCommonMemo.Text = "共通メモ";
        labelCommonMemo.TabIndex = 0;
        //
        // textBoxCommonMemo
        //
        textBoxCommonMemo.Location = new Point(110, 29);
        textBoxCommonMemo.Name = "textBoxCommonMemo";
        textBoxCommonMemo.Size = new Size(738, 23);
        textBoxCommonMemo.Text = "この入力はモードを切り替えても残ります";
        textBoxCommonMemo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxCommonMemo.TabIndex = 1;
        //
        // buttonClose
        //
        buttonClose.Location = new Point(872, 25);
        buttonClose.Name = "buttonClose";
        buttonClose.Size = new Size(120, 32);
        buttonClose.Text = "閉じる";
        buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonClose.UseVisualStyleBackColor = true;
        buttonClose.Click += ButtonClose_Click;
        buttonClose.TabIndex = 2;
        //
        // labelCurrentMode
        //
        labelCurrentMode.Location = new Point(24, 68);
        labelCurrentMode.Name = "labelCurrentMode";
        labelCurrentMode.Size = new Size(968, 24);
        labelCurrentMode.Text = "実行するとモードAを表示します。";
        labelCurrentMode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labelCurrentMode.AutoEllipsis = true;
        labelCurrentMode.TabIndex = 3;
        //
        // panelCenter
        //
        panelCenter.Location = new Point(12, 144);
        panelCenter.Name = "panelCenter";
        panelCenter.Size = new Size(1016, 500);
        panelCenter.Dock = DockStyle.Fill;
        panelCenter.AutoScroll = false;
        panelCenter.BorderStyle = BorderStyle.FixedSingle;
        panelCenter.TabIndex = 2;
        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        ClientSize = new Size(1040, 760);
        Controls.Add(panelCenter);
        Controls.Add(groupBoxBottom);
        Controls.Add(groupBoxTop);
        MinimumSize = new Size(800, 580);
        Padding = new Padding(12);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "WinForms 可変UI設計サンプル";
        Name = "MainForm";
        groupBoxTop.ResumeLayout(false);
        groupBoxTop.PerformLayout();
        groupBoxBottom.ResumeLayout(false);
        groupBoxBottom.PerformLayout();
        panelCenter.ResumeLayout(false);
        panelCenter.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox groupBoxTop;
    private RadioButton radioButtonA;
    private RadioButton radioButtonB;
    private RadioButton radioButtonC;
    private RadioButton radioButtonD;
    private RadioButton radioButtonE;
    private RadioButton radioButtonF;
    private Label labelModeHelp;
    private GroupBox groupBoxBottom;
    private Label labelCommonMemo;
    private TextBox textBoxCommonMemo;
    private Button buttonClose;
    private Label labelCurrentMode;
    private Panel panelCenter;
}
