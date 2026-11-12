#nullable disable

using WinFormsReusableParts.Views.Parts;

namespace WinFormsReusableParts.Views.Pages;

partial class PageAView
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
        partY = new PartYControl();
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
        // partY
        //
        partY.Location = new Point(64, 123);
        partY.Name = "partY";
        partY.Size = new Size(320, 66);
        partY.TabIndex = 1;
        partY.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        partY.Dock = DockStyle.None;
        //
        // PageAView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        AutoScrollMargin = new Size(16, 16);
        Size = new Size(566, 246);
        Name = "PageAView";
        Controls.Add(partX);
        Controls.Add(partY);
        ResumeLayout(false);
    }

    #endregion

    private PartXControl partX;
    private PartYControl partY;
}
