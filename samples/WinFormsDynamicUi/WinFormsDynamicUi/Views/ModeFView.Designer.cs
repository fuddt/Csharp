#nullable disable

namespace WinFormsDynamicUi.Views;

partial class ModeFView
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
        labelModeTitle = new Label();
        labelLayoutHint = new Label();
        groupBoxColor = new GroupBox();
        labelColorChoice = new Label();
        comboBoxColor = new ComboBox();
        buttonApplyColor = new Button();
        groupBoxSwatch = new GroupBox();
        panelSwatch = new Panel();
        labelColor = new Label();
        labelSwatchHelp = new Label();
        groupBoxSize = new GroupBox();
        labelWidth = new Label();
        numericWidth = new NumericUpDown();
        labelHeight = new Label();
        numericHeight = new NumericUpDown();
        buttonApplySize = new Button();
        labelSizeHelp = new Label();
        ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
        groupBoxColor.SuspendLayout();
        groupBoxSwatch.SuspendLayout();
        panelSwatch.SuspendLayout();
        groupBoxSize.SuspendLayout();
        SuspendLayout();
        //
        // labelModeTitle
        //
        labelModeTitle.Location = new Point(16, 14);
        labelModeTitle.Name = "labelModeTitle";
        labelModeTitle.Size = new Size(880, 28);
        labelModeTitle.Text = "Mode F | 色・サイズ";
        labelModeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        labelModeTitle.TabIndex = 0;
        //
        // labelLayoutHint
        //
        labelLayoutHint.Location = new Point(16, 45);
        labelLayoutHint.Name = "labelLayoutHint";
        labelLayoutHint.Size = new Size(900, 24);
        labelLayoutHint.Text = "3つのGroupBoxを段違いに配置。中央の見本の色と大きさを変更できます。";
        labelLayoutHint.TabIndex = 1;
        //
        // groupBoxColor
        //
        groupBoxColor.Controls.Add(labelColorChoice);
        groupBoxColor.Controls.Add(comboBoxColor);
        groupBoxColor.Controls.Add(buttonApplyColor);
        groupBoxColor.Location = new Point(16, 80);
        groupBoxColor.Name = "groupBoxColor";
        groupBoxColor.Size = new Size(270, 196);
        groupBoxColor.Text = "色を選択";
        groupBoxColor.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxColor.Dock = DockStyle.None;
        groupBoxColor.TabStop = false;
        groupBoxColor.TabIndex = 2;
        //
        // labelColorChoice
        //
        labelColorChoice.Location = new Point(20, 32);
        labelColorChoice.Name = "labelColorChoice";
        labelColorChoice.Size = new Size(230, 22);
        labelColorChoice.Text = "見本の色";
        labelColorChoice.TabIndex = 0;
        //
        // comboBoxColor
        //
        comboBoxColor.Location = new Point(20, 64);
        comboBoxColor.Name = "comboBoxColor";
        comboBoxColor.Size = new Size(230, 23);
        comboBoxColor.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxColor.FormattingEnabled = true;
        comboBoxColor.Items.AddRange(new object[] { "青", "緑", "赤" });
        comboBoxColor.TabIndex = 1;
        //
        // buttonApplyColor
        //
        buttonApplyColor.Location = new Point(20, 128);
        buttonApplyColor.Name = "buttonApplyColor";
        buttonApplyColor.Size = new Size(230, 32);
        buttonApplyColor.Text = "色を反映";
        buttonApplyColor.UseVisualStyleBackColor = true;
        buttonApplyColor.Click += ButtonApplyColor_Click;
        buttonApplyColor.TabIndex = 2;
        //
        // groupBoxSwatch
        //
        groupBoxSwatch.Controls.Add(panelSwatch);
        groupBoxSwatch.Controls.Add(labelColor);
        groupBoxSwatch.Controls.Add(labelSwatchHelp);
        groupBoxSwatch.Location = new Point(310, 80);
        groupBoxSwatch.Name = "groupBoxSwatch";
        groupBoxSwatch.Size = new Size(310, 300);
        groupBoxSwatch.Text = "見本";
        groupBoxSwatch.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxSwatch.Dock = DockStyle.None;
        groupBoxSwatch.TabStop = false;
        groupBoxSwatch.TabIndex = 3;
        //
        // panelSwatch
        //
        panelSwatch.Location = new Point(20, 32);
        panelSwatch.Name = "panelSwatch";
        panelSwatch.Size = new Size(160, 80);
        panelSwatch.BackColor = Color.SteelBlue;
        panelSwatch.BorderStyle = BorderStyle.FixedSingle;
        panelSwatch.TabIndex = 0;
        //
        // labelColor
        //
        labelColor.Location = new Point(20, 184);
        labelColor.Name = "labelColor";
        labelColor.Size = new Size(270, 22);
        labelColor.Text = "選択中: 青";
        labelColor.TabIndex = 1;
        //
        // labelSwatchHelp
        //
        labelSwatchHelp.Location = new Point(20, 224);
        labelSwatchHelp.Name = "labelSwatchHelp";
        labelSwatchHelp.Size = new Size(270, 52);
        labelSwatchHelp.Text = "色やサイズはこのViewの中だけで管理します。";
        labelSwatchHelp.TabIndex = 2;
        //
        // groupBoxSize
        //
        groupBoxSize.Controls.Add(labelWidth);
        groupBoxSize.Controls.Add(numericWidth);
        groupBoxSize.Controls.Add(labelHeight);
        groupBoxSize.Controls.Add(numericHeight);
        groupBoxSize.Controls.Add(buttonApplySize);
        groupBoxSize.Controls.Add(labelSizeHelp);
        groupBoxSize.Location = new Point(650, 160);
        groupBoxSize.Name = "groupBoxSize";
        groupBoxSize.Size = new Size(274, 236);
        groupBoxSize.Text = "サイズを指定";
        groupBoxSize.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxSize.Dock = DockStyle.None;
        groupBoxSize.TabStop = false;
        groupBoxSize.TabIndex = 4;
        //
        // labelWidth
        //
        labelWidth.Location = new Point(20, 36);
        labelWidth.Name = "labelWidth";
        labelWidth.Size = new Size(70, 22);
        labelWidth.Text = "幅";
        labelWidth.TabIndex = 0;
        //
        // numericWidth
        //
        numericWidth.Location = new Point(104, 32);
        numericWidth.Name = "numericWidth";
        numericWidth.Size = new Size(144, 23);
        numericWidth.Minimum = 80M;
        numericWidth.Maximum = 240M;
        numericWidth.Value = 160M;
        numericWidth.TabIndex = 1;
        //
        // labelHeight
        //
        labelHeight.Location = new Point(20, 84);
        labelHeight.Name = "labelHeight";
        labelHeight.Size = new Size(70, 22);
        labelHeight.Text = "高さ";
        labelHeight.TabIndex = 2;
        //
        // numericHeight
        //
        numericHeight.Location = new Point(104, 80);
        numericHeight.Name = "numericHeight";
        numericHeight.Size = new Size(144, 23);
        numericHeight.Minimum = 40M;
        numericHeight.Maximum = 120M;
        numericHeight.Value = 80M;
        numericHeight.TabIndex = 3;
        //
        // buttonApplySize
        //
        buttonApplySize.Location = new Point(20, 144);
        buttonApplySize.Name = "buttonApplySize";
        buttonApplySize.Size = new Size(228, 32);
        buttonApplySize.Text = "サイズを反映";
        buttonApplySize.UseVisualStyleBackColor = true;
        buttonApplySize.Click += ButtonApplySize_Click;
        buttonApplySize.TabIndex = 4;
        //
        // labelSizeHelp
        //
        labelSizeHelp.Location = new Point(20, 194);
        labelSizeHelp.Name = "labelSizeHelp";
        labelSizeHelp.Size = new Size(228, 22);
        labelSizeHelp.Text = "幅80～240 / 高さ40～120";
        labelSizeHelp.TabIndex = 5;
        //
        // ModeFView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        AutoScroll = true;
        AutoScrollMinSize = new Size(940, 416);
        Controls.Add(labelModeTitle);
        Controls.Add(labelLayoutHint);
        Controls.Add(groupBoxColor);
        Controls.Add(groupBoxSwatch);
        Controls.Add(groupBoxSize);
        Size = new Size(990, 470);
        Name = "ModeFView";
        ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
        groupBoxColor.ResumeLayout(false);
        groupBoxColor.PerformLayout();
        groupBoxSwatch.ResumeLayout(false);
        groupBoxSwatch.PerformLayout();
        panelSwatch.ResumeLayout(false);
        panelSwatch.PerformLayout();
        groupBoxSize.ResumeLayout(false);
        groupBoxSize.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelModeTitle;
    private Label labelLayoutHint;
    private GroupBox groupBoxColor;
    private Label labelColorChoice;
    private ComboBox comboBoxColor;
    private Button buttonApplyColor;
    private GroupBox groupBoxSwatch;
    private Panel panelSwatch;
    private Label labelColor;
    private Label labelSwatchHelp;
    private GroupBox groupBoxSize;
    private Label labelWidth;
    private NumericUpDown numericWidth;
    private Label labelHeight;
    private NumericUpDown numericHeight;
    private Button buttonApplySize;
    private Label labelSizeHelp;
}
