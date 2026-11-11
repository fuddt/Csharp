#nullable disable

namespace WinFormsDynamicUi.Views;

partial class ModeEView
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
        groupBoxNote = new GroupBox();
        richTextBoxNote = new RichTextBox();
        buttonPreview = new Button();
        groupBoxNotePreview = new GroupBox();
        labelNotePreview = new Label();
        groupBoxNoteOptions = new GroupBox();
        checkBoxShowTitle = new CheckBox();
        groupBoxNote.SuspendLayout();
        groupBoxNotePreview.SuspendLayout();
        groupBoxNoteOptions.SuspendLayout();
        SuspendLayout();
        //
        // labelModeTitle
        //
        labelModeTitle.Location = new Point(16, 14);
        labelModeTitle.Name = "labelModeTitle";
        labelModeTitle.Size = new Size(880, 28);
        labelModeTitle.Text = "Mode E | メモ編集";
        labelModeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        labelModeTitle.TabIndex = 0;
        //
        // labelLayoutHint
        //
        labelLayoutHint.Location = new Point(16, 45);
        labelLayoutHint.Name = "labelLayoutHint";
        labelLayoutHint.Size = new Size(900, 24);
        labelLayoutHint.Text = "広い編集欄・縦長のプレビュー・下段の設定を自由配置。ボタンでプレビューを更新します。";
        labelLayoutHint.TabIndex = 1;
        //
        // groupBoxNote
        //
        groupBoxNote.Controls.Add(richTextBoxNote);
        groupBoxNote.Controls.Add(buttonPreview);
        groupBoxNote.Location = new Point(16, 80);
        groupBoxNote.Name = "groupBoxNote";
        groupBoxNote.Size = new Size(600, 226);
        groupBoxNote.Text = "メモ入力";
        groupBoxNote.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxNote.Dock = DockStyle.None;
        groupBoxNote.TabStop = false;
        groupBoxNote.TabIndex = 2;
        //
        // richTextBoxNote
        //
        richTextBoxNote.Location = new Point(20, 32);
        richTextBoxNote.Name = "richTextBoxNote";
        richTextBoxNote.Size = new Size(560, 126);
        richTextBoxNote.Text = "ここにメモを入力してください。";
        richTextBoxNote.TabIndex = 0;
        //
        // buttonPreview
        //
        buttonPreview.Location = new Point(20, 178);
        buttonPreview.Name = "buttonPreview";
        buttonPreview.Size = new Size(220, 32);
        buttonPreview.Text = "プレビューを更新";
        buttonPreview.UseVisualStyleBackColor = true;
        buttonPreview.Click += ButtonPreview_Click;
        buttonPreview.TabIndex = 1;
        //
        // groupBoxNotePreview
        //
        groupBoxNotePreview.Controls.Add(labelNotePreview);
        groupBoxNotePreview.Location = new Point(640, 80);
        groupBoxNotePreview.Name = "groupBoxNotePreview";
        groupBoxNotePreview.Size = new Size(284, 340);
        groupBoxNotePreview.Text = "プレビュー";
        groupBoxNotePreview.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxNotePreview.Dock = DockStyle.None;
        groupBoxNotePreview.TabStop = false;
        groupBoxNotePreview.TabIndex = 3;
        //
        // labelNotePreview
        //
        labelNotePreview.Location = new Point(20, 32);
        labelNotePreview.Name = "labelNotePreview";
        labelNotePreview.Size = new Size(244, 284);
        labelNotePreview.Text = "ここにメモのプレビューを表示します。";
        labelNotePreview.AutoEllipsis = true;
        labelNotePreview.BorderStyle = BorderStyle.FixedSingle;
        labelNotePreview.TabIndex = 0;
        //
        // groupBoxNoteOptions
        //
        groupBoxNoteOptions.Controls.Add(checkBoxShowTitle);
        groupBoxNoteOptions.Location = new Point(16, 330);
        groupBoxNoteOptions.Name = "groupBoxNoteOptions";
        groupBoxNoteOptions.Size = new Size(440, 100);
        groupBoxNoteOptions.Text = "プレビュー設定";
        groupBoxNoteOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxNoteOptions.Dock = DockStyle.None;
        groupBoxNoteOptions.TabStop = false;
        groupBoxNoteOptions.TabIndex = 4;
        //
        // checkBoxShowTitle
        //
        checkBoxShowTitle.Location = new Point(20, 36);
        checkBoxShowTitle.Name = "checkBoxShowTitle";
        checkBoxShowTitle.Size = new Size(400, 26);
        checkBoxShowTitle.Text = "見出し「メモの内容」を付ける";
        checkBoxShowTitle.Checked = true;
        checkBoxShowTitle.CheckState = CheckState.Checked;
        checkBoxShowTitle.UseVisualStyleBackColor = true;
        checkBoxShowTitle.TabIndex = 0;
        //
        // ModeEView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        AutoScroll = true;
        AutoScrollMinSize = new Size(940, 450);
        Controls.Add(labelModeTitle);
        Controls.Add(labelLayoutHint);
        Controls.Add(groupBoxNote);
        Controls.Add(groupBoxNotePreview);
        Controls.Add(groupBoxNoteOptions);
        Size = new Size(990, 470);
        Name = "ModeEView";
        groupBoxNote.ResumeLayout(false);
        groupBoxNote.PerformLayout();
        groupBoxNotePreview.ResumeLayout(false);
        groupBoxNotePreview.PerformLayout();
        groupBoxNoteOptions.ResumeLayout(false);
        groupBoxNoteOptions.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelModeTitle;
    private Label labelLayoutHint;
    private GroupBox groupBoxNote;
    private RichTextBox richTextBoxNote;
    private Button buttonPreview;
    private GroupBox groupBoxNotePreview;
    private Label labelNotePreview;
    private GroupBox groupBoxNoteOptions;
    private CheckBox checkBoxShowTitle;
}
