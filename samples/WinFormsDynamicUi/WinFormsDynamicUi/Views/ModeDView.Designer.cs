#nullable disable

namespace WinFormsDynamicUi.Views;

partial class ModeDView
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
        groupBoxJobs = new GroupBox();
        checkedListBoxJobs = new CheckedListBox();
        buttonSelectAll = new Button();
        groupBoxOutput = new GroupBox();
        textBoxOutput = new TextBox();
        buttonRun = new Button();
        groupBoxJobs.SuspendLayout();
        groupBoxOutput.SuspendLayout();
        SuspendLayout();
        //
        // labelModeTitle
        //
        labelModeTitle.Location = new Point(16, 14);
        labelModeTitle.Name = "labelModeTitle";
        labelModeTitle.Size = new Size(880, 28);
        labelModeTitle.Text = "Mode D | 項目選択";
        labelModeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        labelModeTitle.TabIndex = 0;
        //
        // labelLayoutHint
        //
        labelLayoutHint.Location = new Point(16, 45);
        labelLayoutHint.Name = "labelLayoutHint";
        labelLayoutHint.Size = new Size(900, 24);
        labelLayoutHint.Text = "左の選択欄と、少し下にずらした右の出力欄。実ファイルの読み書きは行いません。";
        labelLayoutHint.TabIndex = 1;
        //
        // groupBoxJobs
        //
        groupBoxJobs.Controls.Add(checkedListBoxJobs);
        groupBoxJobs.Controls.Add(buttonSelectAll);
        groupBoxJobs.Location = new Point(16, 80);
        groupBoxJobs.Name = "groupBoxJobs";
        groupBoxJobs.Size = new Size(280, 300);
        groupBoxJobs.Text = "処理項目";
        groupBoxJobs.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxJobs.Dock = DockStyle.None;
        groupBoxJobs.TabStop = false;
        groupBoxJobs.TabIndex = 2;
        //
        // checkedListBoxJobs
        //
        checkedListBoxJobs.Location = new Point(20, 32);
        checkedListBoxJobs.Name = "checkedListBoxJobs";
        checkedListBoxJobs.Size = new Size(240, 180);
        checkedListBoxJobs.CheckOnClick = true;
        checkedListBoxJobs.FormattingEnabled = true;
        checkedListBoxJobs.IntegralHeight = false;
        checkedListBoxJobs.Items.AddRange(new object[] { "入力を検証", "データを変換", "結果を書き出す" });
        checkedListBoxJobs.TabIndex = 0;
        //
        // buttonSelectAll
        //
        buttonSelectAll.Location = new Point(20, 240);
        buttonSelectAll.Name = "buttonSelectAll";
        buttonSelectAll.Size = new Size(240, 32);
        buttonSelectAll.Text = "すべて選択";
        buttonSelectAll.UseVisualStyleBackColor = true;
        buttonSelectAll.Click += ButtonSelectAll_Click;
        buttonSelectAll.TabIndex = 1;
        //
        // groupBoxOutput
        //
        groupBoxOutput.Controls.Add(textBoxOutput);
        groupBoxOutput.Controls.Add(buttonRun);
        groupBoxOutput.Location = new Point(320, 124);
        groupBoxOutput.Name = "groupBoxOutput";
        groupBoxOutput.Size = new Size(604, 286);
        groupBoxOutput.Text = "サンプル出力";
        groupBoxOutput.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxOutput.Dock = DockStyle.None;
        groupBoxOutput.TabStop = false;
        groupBoxOutput.TabIndex = 3;
        //
        // textBoxOutput
        //
        textBoxOutput.Location = new Point(20, 32);
        textBoxOutput.Name = "textBoxOutput";
        textBoxOutput.Size = new Size(564, 172);
        textBoxOutput.Text = "「選択内容を表示」を押すと、項目名を表示します。";
        textBoxOutput.Multiline = true;
        textBoxOutput.ReadOnly = true;
        textBoxOutput.ScrollBars = ScrollBars.Vertical;
        textBoxOutput.TabIndex = 0;
        //
        // buttonRun
        //
        buttonRun.Location = new Point(20, 230);
        buttonRun.Name = "buttonRun";
        buttonRun.Size = new Size(240, 32);
        buttonRun.Text = "選択内容を表示";
        buttonRun.UseVisualStyleBackColor = true;
        buttonRun.Click += ButtonRun_Click;
        buttonRun.TabIndex = 1;
        //
        // ModeDView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        AutoScroll = true;
        AutoScrollMinSize = new Size(940, 430);
        Controls.Add(labelModeTitle);
        Controls.Add(labelLayoutHint);
        Controls.Add(groupBoxJobs);
        Controls.Add(groupBoxOutput);
        Size = new Size(990, 470);
        Name = "ModeDView";
        groupBoxJobs.ResumeLayout(false);
        groupBoxJobs.PerformLayout();
        groupBoxOutput.ResumeLayout(false);
        groupBoxOutput.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelModeTitle;
    private Label labelLayoutHint;
    private GroupBox groupBoxJobs;
    private CheckedListBox checkedListBoxJobs;
    private Button buttonSelectAll;
    private GroupBox groupBoxOutput;
    private TextBox textBoxOutput;
    private Button buttonRun;
}
