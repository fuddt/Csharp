#nullable disable

namespace WinFormsDynamicUi.Views;

partial class ModeCView
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
        groupBoxCoordinates = new GroupBox();
        labelX = new Label();
        numericX = new NumericUpDown();
        labelY = new Label();
        numericY = new NumericUpDown();
        buttonApply = new Button();
        labelCoordinates = new Label();
        groupBoxAngle = new GroupBox();
        trackBarAngle = new TrackBar();
        labelAngle = new Label();
        groupBoxDisplay = new GroupBox();
        checkBoxGrid = new CheckBox();
        checkBoxSnap = new CheckBox();
        ((System.ComponentModel.ISupportInitialize)numericX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericY).BeginInit();
        ((System.ComponentModel.ISupportInitialize)trackBarAngle).BeginInit();
        groupBoxCoordinates.SuspendLayout();
        groupBoxAngle.SuspendLayout();
        groupBoxDisplay.SuspendLayout();
        SuspendLayout();
        //
        // labelModeTitle
        //
        labelModeTitle.Location = new Point(16, 14);
        labelModeTitle.Name = "labelModeTitle";
        labelModeTitle.Size = new Size(880, 28);
        labelModeTitle.Text = "Mode C | 座標・角度";
        labelModeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        labelModeTitle.TabIndex = 0;
        //
        // labelLayoutHint
        //
        labelLayoutHint.Location = new Point(16, 45);
        labelLayoutHint.Name = "labelLayoutHint";
        labelLayoutHint.Size = new Size(900, 24);
        labelLayoutHint.Text = "数値入力とスライダーを別のGroupBoxに配置。下段の表示オプションは配置の練習用です。";
        labelLayoutHint.TabIndex = 1;
        //
        // groupBoxCoordinates
        //
        groupBoxCoordinates.Controls.Add(labelX);
        groupBoxCoordinates.Controls.Add(numericX);
        groupBoxCoordinates.Controls.Add(labelY);
        groupBoxCoordinates.Controls.Add(numericY);
        groupBoxCoordinates.Controls.Add(buttonApply);
        groupBoxCoordinates.Controls.Add(labelCoordinates);
        groupBoxCoordinates.Location = new Point(16, 80);
        groupBoxCoordinates.Name = "groupBoxCoordinates";
        groupBoxCoordinates.Size = new Size(420, 192);
        groupBoxCoordinates.Text = "座標";
        groupBoxCoordinates.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxCoordinates.Dock = DockStyle.None;
        groupBoxCoordinates.TabStop = false;
        groupBoxCoordinates.TabIndex = 2;
        //
        // labelX
        //
        labelX.Location = new Point(20, 34);
        labelX.Name = "labelX";
        labelX.Size = new Size(28, 22);
        labelX.Text = "X";
        labelX.TabIndex = 0;
        //
        // numericX
        //
        numericX.Location = new Point(60, 32);
        numericX.Name = "numericX";
        numericX.Size = new Size(120, 23);
        numericX.DecimalPlaces = 1;
        numericX.Minimum = -1000M;
        numericX.Maximum = 1000M;
        numericX.TabIndex = 1;
        //
        // labelY
        //
        labelY.Location = new Point(220, 34);
        labelY.Name = "labelY";
        labelY.Size = new Size(28, 22);
        labelY.Text = "Y";
        labelY.TabIndex = 2;
        //
        // numericY
        //
        numericY.Location = new Point(260, 32);
        numericY.Name = "numericY";
        numericY.Size = new Size(120, 23);
        numericY.DecimalPlaces = 1;
        numericY.Minimum = -1000M;
        numericY.Maximum = 1000M;
        numericY.TabIndex = 3;
        //
        // buttonApply
        //
        buttonApply.Location = new Point(20, 84);
        buttonApply.Name = "buttonApply";
        buttonApply.Size = new Size(160, 32);
        buttonApply.Text = "座標を表示";
        buttonApply.UseVisualStyleBackColor = true;
        buttonApply.Click += ButtonApply_Click;
        buttonApply.TabIndex = 4;
        //
        // labelCoordinates
        //
        labelCoordinates.Location = new Point(20, 140);
        labelCoordinates.Name = "labelCoordinates";
        labelCoordinates.Size = new Size(380, 22);
        labelCoordinates.Text = "X = 0.0, Y = 0.0";
        labelCoordinates.TabIndex = 5;
        //
        // groupBoxAngle
        //
        groupBoxAngle.Controls.Add(trackBarAngle);
        groupBoxAngle.Controls.Add(labelAngle);
        groupBoxAngle.Location = new Point(460, 80);
        groupBoxAngle.Name = "groupBoxAngle";
        groupBoxAngle.Size = new Size(300, 192);
        groupBoxAngle.Text = "角度";
        groupBoxAngle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxAngle.Dock = DockStyle.None;
        groupBoxAngle.TabStop = false;
        groupBoxAngle.TabIndex = 3;
        //
        // trackBarAngle
        //
        trackBarAngle.Location = new Point(20, 32);
        trackBarAngle.Name = "trackBarAngle";
        trackBarAngle.Size = new Size(260, 56);
        trackBarAngle.Maximum = 360;
        trackBarAngle.TickFrequency = 90;
        trackBarAngle.LargeChange = 30;
        trackBarAngle.Value = 90;
        trackBarAngle.ValueChanged += TrackBarAngle_ValueChanged;
        trackBarAngle.TabIndex = 0;
        //
        // labelAngle
        //
        labelAngle.Location = new Point(20, 116);
        labelAngle.Name = "labelAngle";
        labelAngle.Size = new Size(260, 22);
        labelAngle.Text = "角度: 90°";
        labelAngle.TabIndex = 1;
        //
        // groupBoxDisplay
        //
        groupBoxDisplay.Controls.Add(checkBoxGrid);
        groupBoxDisplay.Controls.Add(checkBoxSnap);
        groupBoxDisplay.Location = new Point(220, 304);
        groupBoxDisplay.Name = "groupBoxDisplay";
        groupBoxDisplay.Size = new Size(540, 108);
        groupBoxDisplay.Text = "表示オプション（配置例）";
        groupBoxDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxDisplay.Dock = DockStyle.None;
        groupBoxDisplay.TabStop = false;
        groupBoxDisplay.TabIndex = 4;
        //
        // checkBoxGrid
        //
        checkBoxGrid.Location = new Point(20, 38);
        checkBoxGrid.Name = "checkBoxGrid";
        checkBoxGrid.Size = new Size(230, 26);
        checkBoxGrid.Text = "グリッドを表示";
        checkBoxGrid.Checked = true;
        checkBoxGrid.CheckState = CheckState.Checked;
        checkBoxGrid.UseVisualStyleBackColor = true;
        checkBoxGrid.TabIndex = 0;
        //
        // checkBoxSnap
        //
        checkBoxSnap.Location = new Point(280, 38);
        checkBoxSnap.Name = "checkBoxSnap";
        checkBoxSnap.Size = new Size(230, 26);
        checkBoxSnap.Text = "スナップを有効にする";
        checkBoxSnap.UseVisualStyleBackColor = true;
        checkBoxSnap.TabIndex = 1;
        //
        // ModeCView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        AutoScroll = true;
        AutoScrollMinSize = new Size(940, 432);
        Controls.Add(labelModeTitle);
        Controls.Add(labelLayoutHint);
        Controls.Add(groupBoxCoordinates);
        Controls.Add(groupBoxAngle);
        Controls.Add(groupBoxDisplay);
        Size = new Size(990, 470);
        Name = "ModeCView";
        ((System.ComponentModel.ISupportInitialize)numericX).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericY).EndInit();
        ((System.ComponentModel.ISupportInitialize)trackBarAngle).EndInit();
        groupBoxCoordinates.ResumeLayout(false);
        groupBoxCoordinates.PerformLayout();
        groupBoxAngle.ResumeLayout(false);
        groupBoxAngle.PerformLayout();
        groupBoxDisplay.ResumeLayout(false);
        groupBoxDisplay.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelModeTitle;
    private Label labelLayoutHint;
    private GroupBox groupBoxCoordinates;
    private Label labelX;
    private NumericUpDown numericX;
    private Label labelY;
    private NumericUpDown numericY;
    private Button buttonApply;
    private Label labelCoordinates;
    private GroupBox groupBoxAngle;
    private TrackBar trackBarAngle;
    private Label labelAngle;
    private GroupBox groupBoxDisplay;
    private CheckBox checkBoxGrid;
    private CheckBox checkBoxSnap;
}
