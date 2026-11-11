#nullable disable

namespace WinFormsDynamicUi.Views;

partial class ModeBView
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
        groupBoxFilter = new GroupBox();
        labelThreshold = new Label();
        numericThreshold = new NumericUpDown();
        radioButtonAtLeast = new RadioButton();
        radioButtonAtMost = new RadioButton();
        buttonFilter = new Button();
        groupBoxResults = new GroupBox();
        listBoxResults = new ListBox();
        labelResultCount = new Label();
        ((System.ComponentModel.ISupportInitialize)numericThreshold).BeginInit();
        groupBoxFilter.SuspendLayout();
        groupBoxResults.SuspendLayout();
        SuspendLayout();
        //
        // labelModeTitle
        //
        labelModeTitle.Location = new Point(16, 14);
        labelModeTitle.Name = "labelModeTitle";
        labelModeTitle.Size = new Size(880, 28);
        labelModeTitle.Text = "Mode B | 絞り込み";
        labelModeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        labelModeTitle.TabIndex = 0;
        //
        // labelLayoutHint
        //
        labelLayoutHint.Location = new Point(16, 45);
        labelLayoutHint.Name = "labelLayoutHint";
        labelLayoutHint.Size = new Size(900, 24);
        labelLayoutHint.Text = "左に条件、右に広い結果欄を配置。サンプル値25・55・80を条件で絞り込みます。";
        labelLayoutHint.TabIndex = 1;
        //
        // groupBoxFilter
        //
        groupBoxFilter.Controls.Add(labelThreshold);
        groupBoxFilter.Controls.Add(numericThreshold);
        groupBoxFilter.Controls.Add(radioButtonAtLeast);
        groupBoxFilter.Controls.Add(radioButtonAtMost);
        groupBoxFilter.Controls.Add(buttonFilter);
        groupBoxFilter.Location = new Point(16, 80);
        groupBoxFilter.Name = "groupBoxFilter";
        groupBoxFilter.Size = new Size(290, 282);
        groupBoxFilter.Text = "条件";
        groupBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxFilter.Dock = DockStyle.None;
        groupBoxFilter.TabStop = false;
        groupBoxFilter.TabIndex = 2;
        //
        // labelThreshold
        //
        labelThreshold.Location = new Point(20, 32);
        labelThreshold.Name = "labelThreshold";
        labelThreshold.Size = new Size(240, 22);
        labelThreshold.Text = "しきい値 (0～100)";
        labelThreshold.TabIndex = 0;
        //
        // numericThreshold
        //
        numericThreshold.Location = new Point(20, 64);
        numericThreshold.Name = "numericThreshold";
        numericThreshold.Size = new Size(240, 23);
        numericThreshold.Maximum = 100M;
        numericThreshold.Value = 50M;
        numericThreshold.TabIndex = 1;
        //
        // radioButtonAtLeast
        //
        radioButtonAtLeast.Location = new Point(20, 112);
        radioButtonAtLeast.Name = "radioButtonAtLeast";
        radioButtonAtLeast.Size = new Size(240, 26);
        radioButtonAtLeast.Text = "しきい値以上";
        radioButtonAtLeast.Checked = true;
        radioButtonAtLeast.TabStop = true;
        radioButtonAtLeast.UseVisualStyleBackColor = true;
        radioButtonAtLeast.TabIndex = 2;
        //
        // radioButtonAtMost
        //
        radioButtonAtMost.Location = new Point(20, 152);
        radioButtonAtMost.Name = "radioButtonAtMost";
        radioButtonAtMost.Size = new Size(240, 26);
        radioButtonAtMost.Text = "しきい値以下";
        radioButtonAtMost.UseVisualStyleBackColor = true;
        radioButtonAtMost.TabIndex = 3;
        //
        // buttonFilter
        //
        buttonFilter.Location = new Point(20, 212);
        buttonFilter.Name = "buttonFilter";
        buttonFilter.Size = new Size(240, 32);
        buttonFilter.Text = "絞り込む";
        buttonFilter.UseVisualStyleBackColor = true;
        buttonFilter.Click += ButtonFilter_Click;
        buttonFilter.TabIndex = 4;
        //
        // groupBoxResults
        //
        groupBoxResults.Controls.Add(listBoxResults);
        groupBoxResults.Controls.Add(labelResultCount);
        groupBoxResults.Location = new Point(330, 80);
        groupBoxResults.Name = "groupBoxResults";
        groupBoxResults.Size = new Size(594, 330);
        groupBoxResults.Text = "結果";
        groupBoxResults.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxResults.Dock = DockStyle.None;
        groupBoxResults.TabStop = false;
        groupBoxResults.TabIndex = 3;
        //
        // listBoxResults
        //
        listBoxResults.Location = new Point(20, 32);
        listBoxResults.Name = "listBoxResults";
        listBoxResults.Size = new Size(554, 238);
        listBoxResults.FormattingEnabled = true;
        listBoxResults.IntegralHeight = false;
        listBoxResults.TabIndex = 0;
        //
        // labelResultCount
        //
        labelResultCount.Location = new Point(20, 288);
        labelResultCount.Name = "labelResultCount";
        labelResultCount.Size = new Size(554, 22);
        labelResultCount.Text = "条件を設定して「絞り込む」を押してください。";
        labelResultCount.TabIndex = 1;
        //
        // ModeBView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        AutoScroll = true;
        AutoScrollMinSize = new Size(940, 430);
        Controls.Add(labelModeTitle);
        Controls.Add(labelLayoutHint);
        Controls.Add(groupBoxFilter);
        Controls.Add(groupBoxResults);
        Size = new Size(990, 470);
        Name = "ModeBView";
        ((System.ComponentModel.ISupportInitialize)numericThreshold).EndInit();
        groupBoxFilter.ResumeLayout(false);
        groupBoxFilter.PerformLayout();
        groupBoxResults.ResumeLayout(false);
        groupBoxResults.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelModeTitle;
    private Label labelLayoutHint;
    private GroupBox groupBoxFilter;
    private Label labelThreshold;
    private NumericUpDown numericThreshold;
    private RadioButton radioButtonAtLeast;
    private RadioButton radioButtonAtMost;
    private Button buttonFilter;
    private GroupBox groupBoxResults;
    private ListBox listBoxResults;
    private Label labelResultCount;
}
