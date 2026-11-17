#nullable disable

namespace WinFormsEscFocusReturn.Forms;

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

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        labelTitle = new Label();
        labelIntro = new Label();
        labelFocusStatus = new Label();
        checkBoxUseOwner = new CheckBox();
        buttonOpenSmallForm = new Button();
        labelMainInput = new Label();
        textBoxMainInput = new TextBox();
        labelNote = new Label();
        SuspendLayout();
        //
        // labelTitle
        //
        labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        labelTitle.Location = new Point(28, 24);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new Size(704, 34);
        labelTitle.TabIndex = 0;
        labelTitle.Text = "WinForms：小さいFormから Esc でメインFormへフォーカスを移す";
        //
        // labelIntro
        //
        labelIntro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labelIntro.Location = new Point(30, 66);
        labelIntro.Name = "labelIntro";
        labelIntro.Size = new Size(700, 40);
        labelIntro.TabIndex = 1;
        labelIntro.Text = "小さいFormを ShowDialog() ではなく Show(this) で開き、ProcessCmdKey で Esc を捕捉してメインFormを Activate() します。";
        //
        // labelFocusStatus
        //
        labelFocusStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labelFocusStatus.BorderStyle = BorderStyle.FixedSingle;
        labelFocusStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        labelFocusStatus.Location = new Point(30, 114);
        labelFocusStatus.Name = "labelFocusStatus";
        labelFocusStatus.Padding = new Padding(8, 0, 8, 0);
        labelFocusStatus.Size = new Size(700, 34);
        labelFocusStatus.TabIndex = 2;
        labelFocusStatus.Text = "状態：";
        labelFocusStatus.TextAlign = ContentAlignment.MiddleLeft;
        //
        // checkBoxUseOwner
        //
        checkBoxUseOwner.Checked = true;
        checkBoxUseOwner.CheckState = CheckState.Checked;
        checkBoxUseOwner.Location = new Point(30, 166);
        checkBoxUseOwner.Name = "checkBoxUseOwner";
        checkBoxUseOwner.Size = new Size(480, 24);
        checkBoxUseOwner.TabIndex = 3;
        checkBoxUseOwner.Text = "Owner を指定して開く（Show(this)：小さいFormを常に手前に残す）";
        checkBoxUseOwner.UseVisualStyleBackColor = true;
        //
        // buttonOpenSmallForm
        //
        buttonOpenSmallForm.Location = new Point(30, 202);
        buttonOpenSmallForm.Name = "buttonOpenSmallForm";
        buttonOpenSmallForm.Size = new Size(210, 34);
        buttonOpenSmallForm.TabIndex = 4;
        buttonOpenSmallForm.Text = "小さいFormを開く";
        buttonOpenSmallForm.UseVisualStyleBackColor = true;
        buttonOpenSmallForm.Click += ButtonOpenSmallForm_Click;
        //
        // labelMainInput
        //
        labelMainInput.Location = new Point(30, 256);
        labelMainInput.Name = "labelMainInput";
        labelMainInput.Size = new Size(310, 22);
        labelMainInput.TabIndex = 5;
        labelMainInput.Text = "メインForm側の入力欄（フォーカス復帰の確認用）";
        //
        // textBoxMainInput
        //
        textBoxMainInput.Location = new Point(30, 282);
        textBoxMainInput.Name = "textBoxMainInput";
        textBoxMainInput.PlaceholderText = "フォーカスが戻ったら入力できます";
        textBoxMainInput.Size = new Size(300, 23);
        textBoxMainInput.TabIndex = 6;
        //
        // labelNote
        //
        labelNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
        labelNote.ForeColor = SystemColors.GrayText;
        labelNote.Location = new Point(30, 326);
        labelNote.Name = "labelNote";
        labelNote.Size = new Size(310, 96);
        labelNote.TabIndex = 7;
        labelNote.Text = "確認手順：\r\n1. 「小さいFormを開く」を押す\r\n2. 小さいForm内で Esc キーを押す\r\n3. 小さいFormは閉じずに、上の状態表示が\r\n　「メインForm がアクティブ」に戻る";
        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(760, 440);
        Controls.Add(labelTitle);
        Controls.Add(labelIntro);
        Controls.Add(labelFocusStatus);
        Controls.Add(checkBoxUseOwner);
        Controls.Add(buttonOpenSmallForm);
        Controls.Add(labelMainInput);
        Controls.Add(textBoxMainInput);
        Controls.Add(labelNote);
        MinimumSize = new Size(560, 380);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "WinForms Esc フォーカス移動サンプル";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelTitle;
    private Label labelIntro;
    private Label labelFocusStatus;
    private CheckBox checkBoxUseOwner;
    private Button buttonOpenSmallForm;
    private Label labelMainInput;
    private TextBox textBoxMainInput;
    private Label labelNote;
}
