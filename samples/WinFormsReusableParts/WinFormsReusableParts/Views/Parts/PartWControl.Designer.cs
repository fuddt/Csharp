#nullable disable

namespace WinFormsReusableParts.Views.Parts;

partial class PartWControl
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
        checkBoxShowGuides = new CheckBox();
        groupBoxPart.SuspendLayout();
        SuspendLayout();
        //
        // groupBoxPart
        //
        groupBoxPart.Text = "W  補助表示";
        groupBoxPart.Location = new Point(0, 0);
        groupBoxPart.Name = "groupBoxPart";
        groupBoxPart.Size = new Size(320, 66);
        groupBoxPart.TabIndex = 0;
        groupBoxPart.TabStop = false;
        groupBoxPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxPart.Controls.Add(checkBoxShowGuides);
        //
        // checkBoxShowGuides
        //
        checkBoxShowGuides.Text = "ガイドを表示する";
        checkBoxShowGuides.Location = new Point(16, 24);
        checkBoxShowGuides.Name = "checkBoxShowGuides";
        checkBoxShowGuides.Size = new Size(288, 24);
        checkBoxShowGuides.TabIndex = 0;
        checkBoxShowGuides.UseVisualStyleBackColor = true;
        //
        // PartWControl
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Size = new Size(320, 66);
        Name = "PartWControl";
        Controls.Add(groupBoxPart);
        groupBoxPart.ResumeLayout(false);
        groupBoxPart.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBoxPart;
    private CheckBox checkBoxShowGuides;
}
