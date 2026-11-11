#nullable disable

namespace WinFormsReusableParts.Views.Parts;

partial class PartYControl
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
        checkBoxValidateInput = new CheckBox();
        groupBoxPart.SuspendLayout();
        SuspendLayout();
        //
        // groupBoxPart
        //
        groupBoxPart.Text = "Y  入力確認";
        groupBoxPart.Location = new Point(0, 0);
        groupBoxPart.Name = "groupBoxPart";
        groupBoxPart.Size = new Size(320, 66);
        groupBoxPart.TabIndex = 0;
        groupBoxPart.TabStop = false;
        groupBoxPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxPart.Controls.Add(checkBoxValidateInput);
        //
        // checkBoxValidateInput
        //
        checkBoxValidateInput.Text = "入力値を検証する";
        checkBoxValidateInput.Location = new Point(16, 24);
        checkBoxValidateInput.Name = "checkBoxValidateInput";
        checkBoxValidateInput.Size = new Size(288, 24);
        checkBoxValidateInput.TabIndex = 0;
        checkBoxValidateInput.UseVisualStyleBackColor = true;
        //
        // PartYControl
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Size = new Size(320, 66);
        Name = "PartYControl";
        Controls.Add(groupBoxPart);
        groupBoxPart.ResumeLayout(false);
        groupBoxPart.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBoxPart;
    private CheckBox checkBoxValidateInput;
}
