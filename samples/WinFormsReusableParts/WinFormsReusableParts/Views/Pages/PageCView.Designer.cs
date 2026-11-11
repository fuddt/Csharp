#nullable disable

using WinFormsReusableParts.Views.Parts;

namespace WinFormsReusableParts.Views.Pages;

partial class PageCView
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
        partW = new PartWControl();
        partX = new PartXControl();
        SuspendLayout();
        //
        // partW
        //
        partW.Location = new Point(16, 16);
        partW.Name = "partW";
        partW.Size = new Size(320, 66);
        partW.TabIndex = 0;
        partW.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        partW.Dock = DockStyle.None;
        //
        // partX
        //
        partX.Location = new Point(84, 104);
        partX.Name = "partX";
        partX.Size = new Size(356, 90);
        partX.TabIndex = 1;
        partX.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        partX.Dock = DockStyle.None;
        //
        // PageCView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        AutoScrollMargin = new Size(16, 16);
        Size = new Size(566, 246);
        Name = "PageCView";
        Controls.Add(partW);
        Controls.Add(partX);
        ResumeLayout(false);
    }

    #endregion

    private PartWControl partW;
    private PartXControl partX;
}
