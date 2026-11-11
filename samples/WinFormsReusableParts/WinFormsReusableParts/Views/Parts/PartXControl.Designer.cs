#nullable disable

namespace WinFormsReusableParts.Views.Parts;

partial class PartXControl
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
        checkBoxShowPreview = new CheckBox();
        checkBoxUseActualSize = new CheckBox();
        groupBoxPart.SuspendLayout();
        SuspendLayout();
        //
        // groupBoxPart
        //
        groupBoxPart.Text = "X  プレビュー";
        groupBoxPart.Location = new Point(0, 0);
        groupBoxPart.Name = "groupBoxPart";
        groupBoxPart.Size = new Size(356, 90);
        groupBoxPart.TabIndex = 0;
        groupBoxPart.TabStop = false;
        groupBoxPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxPart.Controls.Add(checkBoxShowPreview);
        groupBoxPart.Controls.Add(checkBoxUseActualSize);
        //
        // checkBoxShowPreview
        //
        checkBoxShowPreview.Text = "プレビューを表示する";
        checkBoxShowPreview.Location = new Point(16, 24);
        checkBoxShowPreview.Name = "checkBoxShowPreview";
        checkBoxShowPreview.Size = new Size(324, 24);
        checkBoxShowPreview.TabIndex = 0;
        checkBoxShowPreview.UseVisualStyleBackColor = true;
        //
        // checkBoxUseActualSize
        //
        checkBoxUseActualSize.Text = "原寸で表示する";
        checkBoxUseActualSize.Location = new Point(16, 53);
        checkBoxUseActualSize.Name = "checkBoxUseActualSize";
        checkBoxUseActualSize.Size = new Size(324, 24);
        checkBoxUseActualSize.TabIndex = 1;
        checkBoxUseActualSize.UseVisualStyleBackColor = true;
        //
        // PartXControl
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Size = new Size(356, 90);
        Name = "PartXControl";
        Controls.Add(groupBoxPart);
        groupBoxPart.ResumeLayout(false);
        groupBoxPart.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBoxPart;
    private CheckBox checkBoxShowPreview;
    private CheckBox checkBoxUseActualSize;
}
