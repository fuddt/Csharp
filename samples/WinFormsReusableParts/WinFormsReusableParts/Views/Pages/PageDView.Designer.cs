#nullable disable

using WinFormsReusableParts.Views.Parts;

namespace WinFormsReusableParts.Views.Pages;

partial class PageDView
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
        partY = new PartYControl();
        partZ = new PartZControl();
        SuspendLayout();
        //
        // partY
        //
        partY.Location = new Point(24, 16);
        partY.Name = "partY";
        partY.Size = new Size(320, 66);
        partY.TabIndex = 0;
        partY.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        partY.Dock = DockStyle.None;
        //
        // partZ
        //
        partZ.Location = new Point(88, 110);
        partZ.Name = "partZ";
        partZ.Size = new Size(320, 66);
        partZ.TabIndex = 1;
        partZ.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        partZ.Dock = DockStyle.None;
        //
        // PageDView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        AutoScrollMargin = new Size(16, 16);
        Size = new Size(566, 246);
        Name = "PageDView";
        Controls.Add(partY);
        Controls.Add(partZ);
        ResumeLayout(false);
    }

    #endregion

    private PartYControl partY;
    private PartZControl partZ;
}
