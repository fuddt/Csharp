#nullable disable

using WinFormsReusableParts.Views.Parts;

namespace WinFormsReusableParts.Views.Pages;

partial class PageBView
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
        partX = new PartXControl();
        partZ = new PartZControl();
        SuspendLayout();
        //
        // partX
        //
        partX.Location = new Point(16, 16);
        partX.Name = "partX";
        partX.Size = new Size(356, 90);
        partX.TabIndex = 0;
        partX.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        partX.Dock = DockStyle.None;
        //
        // partZ
        //
        partZ.Location = new Point(128, 123);
        partZ.Name = "partZ";
        partZ.Size = new Size(320, 66);
        partZ.TabIndex = 1;
        partZ.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        partZ.Dock = DockStyle.None;
        //
        // PageBView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        AutoScrollMargin = new Size(16, 16);
        Size = new Size(566, 246);
        Name = "PageBView";
        Controls.Add(partX);
        Controls.Add(partZ);
        ResumeLayout(false);
    }

    #endregion

    private PartXControl partX;
    private PartZControl partZ;
}
