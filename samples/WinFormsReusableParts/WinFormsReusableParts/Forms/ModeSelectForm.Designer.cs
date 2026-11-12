#nullable disable

using WinFormsReusableParts.Views.Parts;

namespace WinFormsReusableParts.Forms;

partial class ModeSelectForm
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
        groupBoxModes = new GroupBox();
        radioButtonA = new RadioButton();
        radioButtonB = new RadioButton();
        radioButtonC = new RadioButton();
        radioButtonD = new RadioButton();
        radioButtonE = new RadioButton();
        panelPageHost = new Panel();
        partX = new PartXControl();
        partY = new PartYControl();
        partZ = new PartZControl();
        partW = new PartWControl();
        partE = new PartEControl();
        groupBoxResult = new GroupBox();
        buttonGetCheckedTexts = new Button();
        textBoxResult = new TextBox();
        buttonClose = new Button();
        groupBoxModes.SuspendLayout();
        panelPageHost.SuspendLayout();
        groupBoxResult.SuspendLayout();
        SuspendLayout();
        //
        // groupBoxModes
        //
        groupBoxModes.Text = "モード";
        groupBoxModes.Location = new Point(12, 12);
        groupBoxModes.Name = "groupBoxModes";
        groupBoxModes.Size = new Size(568, 72);
        groupBoxModes.TabIndex = 0;
        groupBoxModes.TabStop = false;
        groupBoxModes.Dock = DockStyle.Top;
        groupBoxModes.Controls.Add(radioButtonA);
        groupBoxModes.Controls.Add(radioButtonB);
        groupBoxModes.Controls.Add(radioButtonC);
        groupBoxModes.Controls.Add(radioButtonD);
        groupBoxModes.Controls.Add(radioButtonE);
        //
        // radioButtonA
        //
        radioButtonA.Text = "A";
        radioButtonA.Location = new Point(18, 28);
        radioButtonA.Name = "radioButtonA";
        radioButtonA.Size = new Size(58, 28);
        radioButtonA.TabIndex = 0;
        radioButtonA.Checked = true;
        radioButtonA.Tag = "A";
        radioButtonA.TabStop = true;
        radioButtonA.UseVisualStyleBackColor = true;
        radioButtonA.CheckedChanged += ModeRadioButton_CheckedChanged;
        //
        // radioButtonB
        //
        radioButtonB.Text = "B";
        radioButtonB.Location = new Point(88, 28);
        radioButtonB.Name = "radioButtonB";
        radioButtonB.Size = new Size(58, 28);
        radioButtonB.TabIndex = 1;
        radioButtonB.Checked = false;
        radioButtonB.Tag = "B";
        radioButtonB.TabStop = false;
        radioButtonB.UseVisualStyleBackColor = true;
        radioButtonB.CheckedChanged += ModeRadioButton_CheckedChanged;
        //
        // radioButtonC
        //
        radioButtonC.Text = "C";
        radioButtonC.Location = new Point(158, 28);
        radioButtonC.Name = "radioButtonC";
        radioButtonC.Size = new Size(58, 28);
        radioButtonC.TabIndex = 2;
        radioButtonC.Checked = false;
        radioButtonC.Tag = "C";
        radioButtonC.TabStop = false;
        radioButtonC.UseVisualStyleBackColor = true;
        radioButtonC.CheckedChanged += ModeRadioButton_CheckedChanged;
        //
        // radioButtonD
        //
        radioButtonD.Text = "D";
        radioButtonD.Location = new Point(228, 28);
        radioButtonD.Name = "radioButtonD";
        radioButtonD.Size = new Size(58, 28);
        radioButtonD.TabIndex = 3;
        radioButtonD.Checked = false;
        radioButtonD.Tag = "D";
        radioButtonD.TabStop = false;
        radioButtonD.UseVisualStyleBackColor = true;
        radioButtonD.CheckedChanged += ModeRadioButton_CheckedChanged;
        //
        // radioButtonE
        //
        radioButtonE.Text = "E";
        radioButtonE.Location = new Point(298, 28);
        radioButtonE.Name = "radioButtonE";
        radioButtonE.Size = new Size(58, 28);
        radioButtonE.TabIndex = 4;
        radioButtonE.Checked = false;
        radioButtonE.Tag = "E";
        radioButtonE.TabStop = false;
        radioButtonE.UseVisualStyleBackColor = true;
        radioButtonE.CheckedChanged += ModeRadioButton_CheckedChanged;
        //
        // panelPageHost
        //
        panelPageHost.Location = new Point(12, 84);
        panelPageHost.Name = "panelPageHost";
        panelPageHost.Size = new Size(568, 248);
        panelPageHost.TabIndex = 1;
        panelPageHost.AutoScroll = true;
        panelPageHost.AutoScrollMargin = new Size(16, 16);
        panelPageHost.BorderStyle = BorderStyle.FixedSingle;
        panelPageHost.Dock = DockStyle.Fill;
        panelPageHost.Controls.Add(partX);
        panelPageHost.Controls.Add(partY);
        panelPageHost.Controls.Add(partZ);
        panelPageHost.Controls.Add(partW);
        panelPageHost.Controls.Add(partE);
        //
        // partX
        //
        partX.Location = new Point(16, 16);
        partX.Name = "partX";
        partX.Size = new Size(356, 90);
        partX.TabIndex = 0;
        partX.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        //
        // partY
        //
        partY.Location = new Point(16, 118);
        partY.Name = "partY";
        partY.Size = new Size(356, 60);
        partY.TabIndex = 1;
        partY.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        //
        // partZ
        //
        partZ.Location = new Point(16, 190);
        partZ.Name = "partZ";
        partZ.Size = new Size(356, 60);
        partZ.TabIndex = 2;
        partZ.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        //
        // partW
        //
        partW.Location = new Point(16, 262);
        partW.Name = "partW";
        partW.Size = new Size(356, 60);
        partW.TabIndex = 3;
        partW.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        //
        // partE
        //
        partE.Location = new Point(16, 334);
        partE.Name = "partE";
        partE.Size = new Size(356, 78);
        partE.TabIndex = 4;
        partE.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        //
        // groupBoxResult
        //
        groupBoxResult.Text = "チェック済み項目";
        groupBoxResult.Location = new Point(12, 332);
        groupBoxResult.Name = "groupBoxResult";
        groupBoxResult.Size = new Size(568, 128);
        groupBoxResult.TabIndex = 2;
        groupBoxResult.TabStop = false;
        groupBoxResult.Dock = DockStyle.Bottom;
        groupBoxResult.Controls.Add(buttonGetCheckedTexts);
        groupBoxResult.Controls.Add(textBoxResult);
        groupBoxResult.Controls.Add(buttonClose);
        //
        // buttonGetCheckedTexts
        //
        buttonGetCheckedTexts.Text = "取得";
        buttonGetCheckedTexts.Location = new Point(436, 25);
        buttonGetCheckedTexts.Name = "buttonGetCheckedTexts";
        buttonGetCheckedTexts.Size = new Size(120, 32);
        buttonGetCheckedTexts.TabIndex = 0;
        buttonGetCheckedTexts.UseVisualStyleBackColor = true;
        buttonGetCheckedTexts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonGetCheckedTexts.Click += ButtonGetCheckedTexts_Click;
        //
        // textBoxResult
        //
        textBoxResult.Location = new Point(12, 25);
        textBoxResult.Name = "textBoxResult";
        textBoxResult.TabIndex = 1;
        textBoxResult.AccessibleName = "チェック済み項目の取得結果";
        textBoxResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxResult.Multiline = true;
        textBoxResult.Size = new Size(408, 89);
        textBoxResult.ReadOnly = true;
        textBoxResult.ScrollBars = ScrollBars.Vertical;
        //
        // buttonClose
        //
        buttonClose.Text = "閉じる";
        buttonClose.Location = new Point(436, 72);
        buttonClose.Name = "buttonClose";
        buttonClose.Size = new Size(120, 32);
        buttonClose.TabIndex = 2;
        buttonClose.UseVisualStyleBackColor = true;
        buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonClose.DialogResult = DialogResult.Cancel;
        //
        // ModeSelectForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(592, 472);
        CancelButton = buttonClose;
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(436, 370);
        Padding = new Padding(12);
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "モード選択";
        Name = "ModeSelectForm";
        Controls.Add(panelPageHost);
        Controls.Add(groupBoxResult);
        Controls.Add(groupBoxModes);
        groupBoxModes.ResumeLayout(false);
        groupBoxModes.PerformLayout();
        panelPageHost.ResumeLayout(false);
        groupBoxResult.ResumeLayout(false);
        groupBoxResult.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBoxModes;
    private RadioButton radioButtonA;
    private RadioButton radioButtonB;
    private RadioButton radioButtonC;
    private RadioButton radioButtonD;
    private RadioButton radioButtonE;
    private Panel panelPageHost;
    private PartXControl partX;
    private PartYControl partY;
    private PartZControl partZ;
    private PartWControl partW;
    private PartEControl partE;
    private GroupBox groupBoxResult;
    private Button buttonGetCheckedTexts;
    private TextBox textBoxResult;
    private Button buttonClose;
}
