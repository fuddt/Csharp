#nullable disable

namespace WinFormsReusableParts.Views.Parts;

partial class PartEControl
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
        groupBoxPart = new GroupBox();
        textBoxLastEInput = new TextBox();
        groupBoxPart.SuspendLayout();
        SuspendLayout();
        //
        // groupBoxPart
        //
        groupBoxPart.Text = "最後に入力したテキスト";
        groupBoxPart.Location = new Point(0, 0);
        groupBoxPart.Name = "groupBoxPart";
        groupBoxPart.Size = new Size(356, 78);
        groupBoxPart.TabIndex = 0;
        groupBoxPart.TabStop = false;
        groupBoxPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxPart.Controls.Add(textBoxLastEInput);
        //
        // textBoxLastEInput
        //
        textBoxLastEInput.Location = new Point(16, 30);
        textBoxLastEInput.Name = "textBoxLastEInput";
        textBoxLastEInput.Size = new Size(324, 23);
        textBoxLastEInput.TabIndex = 0;
        textBoxLastEInput.AccessibleName = "最後に入力したテキスト";
        textBoxLastEInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        //
        // PartEControl
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Size = new Size(356, 78);
        Name = "PartEControl";
        Controls.Add(groupBoxPart);
        groupBoxPart.ResumeLayout(false);
        groupBoxPart.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBoxPart;
    private TextBox textBoxLastEInput;
}
