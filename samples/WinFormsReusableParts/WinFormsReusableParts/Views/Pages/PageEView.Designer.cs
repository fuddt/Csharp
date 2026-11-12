#nullable disable

using WinFormsReusableParts.Views.Parts;

namespace WinFormsReusableParts.Views.Pages;

partial class PageEView
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
        groupBoxLastEInput = new GroupBox();
        textBoxLastEInput = new TextBox();
        partX = new PartXControl();
        groupBoxLastEInput.SuspendLayout();
        SuspendLayout();
        //
        // groupBoxLastEInput
        //
        groupBoxLastEInput.Text = "最後に入力したテキスト";
        groupBoxLastEInput.Location = new Point(16, 16);
        groupBoxLastEInput.Name = "groupBoxLastEInput";
        groupBoxLastEInput.Size = new Size(416, 78);
        groupBoxLastEInput.TabIndex = 0;
        groupBoxLastEInput.TabStop = false;
        groupBoxLastEInput.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxLastEInput.Dock = DockStyle.None;
        groupBoxLastEInput.Controls.Add(textBoxLastEInput);
        //
        // textBoxLastEInput
        //
        textBoxLastEInput.Location = new Point(16, 30);
        textBoxLastEInput.Name = "textBoxLastEInput";
        textBoxLastEInput.Size = new Size(384, 23);
        textBoxLastEInput.TabIndex = 0;
        textBoxLastEInput.AccessibleName = "最後に入力したテキスト";
        textBoxLastEInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        //
        // partX
        //
        partX.Location = new Point(76, 114);
        partX.Name = "partX";
        partX.Size = new Size(356, 90);
        partX.TabIndex = 1;
        partX.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        partX.Dock = DockStyle.None;
        //
        // PageEView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        AutoScrollMargin = new Size(16, 16);
        Size = new Size(566, 246);
        Name = "PageEView";
        Controls.Add(groupBoxLastEInput);
        Controls.Add(partX);
        groupBoxLastEInput.ResumeLayout(false);
        groupBoxLastEInput.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBoxLastEInput;
    private TextBox textBoxLastEInput;
    private PartXControl partX;
}
