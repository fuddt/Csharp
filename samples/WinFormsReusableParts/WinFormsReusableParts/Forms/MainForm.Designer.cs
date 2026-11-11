#nullable disable

namespace WinFormsReusableParts.Forms;

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
        buttonOpenSettings = new Button();
        SuspendLayout();
        //
        // labelTitle
        //
        labelTitle.Text = "WinForms 可変UIサンプル";
        labelTitle.Location = new Point(28, 32);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new Size(702, 36);
        labelTitle.TabIndex = 0;
        labelTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        //
        // labelIntro
        //
        labelIntro.Text = "モードを切り替えて、チェック項目と入力欄の状態を確認できます。";
        labelIntro.Location = new Point(30, 79);
        labelIntro.Name = "labelIntro";
        labelIntro.Size = new Size(698, 38);
        labelIntro.TabIndex = 1;
        labelIntro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        //
        // buttonOpenSettings
        //
        buttonOpenSettings.Text = "設定画面を開く";
        buttonOpenSettings.Location = new Point(30, 132);
        buttonOpenSettings.Name = "buttonOpenSettings";
        buttonOpenSettings.Size = new Size(198, 32);
        buttonOpenSettings.TabIndex = 2;
        buttonOpenSettings.UseVisualStyleBackColor = true;
        buttonOpenSettings.Click += ButtonOpenSettings_Click;
        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(760, 520);
        MinimumSize = new Size(520, 260);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "WinForms 可変UIサンプル";
        Name = "MainForm";
        Controls.Add(labelTitle);
        Controls.Add(labelIntro);
        Controls.Add(buttonOpenSettings);
        ResumeLayout(false);
    }

    #endregion

    private Label labelTitle;
    private Label labelIntro;
    private Button buttonOpenSettings;
}
