#nullable disable

namespace WinFormsReusableParts.Views.Parts;

partial class PartZControl
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
        checkBoxIncludeTime = new CheckBox();
        groupBoxPart.SuspendLayout();
        SuspendLayout();
        //
        // groupBoxPart
        //
        groupBoxPart.Text = "Z  出力";
        groupBoxPart.Location = new Point(0, 0);
        groupBoxPart.Name = "groupBoxPart";
        groupBoxPart.Size = new Size(320, 66);
        groupBoxPart.TabIndex = 0;
        groupBoxPart.TabStop = false;
        groupBoxPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxPart.Controls.Add(checkBoxIncludeTime);
        //
        // checkBoxIncludeTime
        //
        checkBoxIncludeTime.Text = "結果に時刻を含める";
        checkBoxIncludeTime.Location = new Point(16, 24);
        checkBoxIncludeTime.Name = "checkBoxIncludeTime";
        checkBoxIncludeTime.Size = new Size(288, 24);
        checkBoxIncludeTime.TabIndex = 0;
        checkBoxIncludeTime.UseVisualStyleBackColor = true;
        //
        // PartZControl
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Size = new Size(320, 66);
        Name = "PartZControl";
        Controls.Add(groupBoxPart);
        groupBoxPart.ResumeLayout(false);
        groupBoxPart.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBoxPart;
    private CheckBox checkBoxIncludeTime;
}
