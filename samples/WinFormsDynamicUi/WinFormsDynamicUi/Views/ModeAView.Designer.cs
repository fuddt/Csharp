#nullable disable

namespace WinFormsDynamicUi.Views;

partial class ModeAView
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

    #region Designer code

    private void InitializeComponent()
    {
        labelModeTitle = new Label();
        labelLayoutHint = new Label();
        groupBoxInput = new GroupBox();
        labelName = new Label();
        textBoxName = new TextBox();
        labelQuantity = new Label();
        numericQuantity = new NumericUpDown();
        buttonPreview = new Button();
        labelPreview = new Label();
        groupBoxCategory = new GroupBox();
        labelCategory = new Label();
        comboBoxCategory = new ComboBox();
        groupBoxOptions = new GroupBox();
        checkBoxNotify = new CheckBox();
        checkBoxArchive = new CheckBox();
        ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
        groupBoxInput.SuspendLayout();
        groupBoxCategory.SuspendLayout();
        groupBoxOptions.SuspendLayout();
        SuspendLayout();
        //
        // labelModeTitle
        //
        labelModeTitle.Location = new Point(16, 14);
        labelModeTitle.Name = "labelModeTitle";
        labelModeTitle.Size = new Size(880, 28);
        labelModeTitle.Text = "Mode A | 基本入力";
        labelModeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        labelModeTitle.TabIndex = 0;
        //
        // labelLayoutHint
        //
        labelLayoutHint.Location = new Point(16, 45);
        labelLayoutHint.Name = "labelLayoutHint";
        labelLayoutHint.Size = new Size(900, 24);
        labelLayoutHint.Text = "3つのGroupBoxを横方向に自由配置。名前・数量・カテゴリを組み合わせて表示します。";
        labelLayoutHint.TabIndex = 1;
        //
        // groupBoxInput
        //
        groupBoxInput.Controls.Add(labelName);
        groupBoxInput.Controls.Add(textBoxName);
        groupBoxInput.Controls.Add(labelQuantity);
        groupBoxInput.Controls.Add(numericQuantity);
        groupBoxInput.Controls.Add(buttonPreview);
        groupBoxInput.Controls.Add(labelPreview);
        groupBoxInput.Location = new Point(16, 80);
        groupBoxInput.Name = "groupBoxInput";
        groupBoxInput.Size = new Size(340, 246);
        groupBoxInput.Text = "入力";
        groupBoxInput.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxInput.Dock = DockStyle.None;
        groupBoxInput.TabStop = false;
        groupBoxInput.TabIndex = 2;
        //
        // labelName
        //
        labelName.Location = new Point(20, 30);
        labelName.Name = "labelName";
        labelName.Size = new Size(80, 22);
        labelName.Text = "名前";
        labelName.TabIndex = 0;
        //
        // textBoxName
        //
        textBoxName.Location = new Point(20, 56);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new Size(300, 23);
        textBoxName.Text = "サンプル";
        textBoxName.TabIndex = 1;
        //
        // labelQuantity
        //
        labelQuantity.Location = new Point(20, 94);
        labelQuantity.Name = "labelQuantity";
        labelQuantity.Size = new Size(80, 22);
        labelQuantity.Text = "数量";
        labelQuantity.TabIndex = 2;
        //
        // numericQuantity
        //
        numericQuantity.Location = new Point(120, 92);
        numericQuantity.Name = "numericQuantity";
        numericQuantity.Size = new Size(120, 23);
        numericQuantity.Minimum = 1M;
        numericQuantity.Maximum = 100M;
        numericQuantity.Value = 1M;
        numericQuantity.TabIndex = 3;
        //
        // buttonPreview
        //
        buttonPreview.Location = new Point(20, 136);
        buttonPreview.Name = "buttonPreview";
        buttonPreview.Size = new Size(160, 32);
        buttonPreview.Text = "入力内容を表示";
        buttonPreview.UseVisualStyleBackColor = true;
        buttonPreview.Click += ButtonPreview_Click;
        buttonPreview.TabIndex = 4;
        //
        // labelPreview
        //
        labelPreview.Location = new Point(20, 186);
        labelPreview.Name = "labelPreview";
        labelPreview.Size = new Size(300, 44);
        labelPreview.Text = "ここに入力内容を表示します。";
        labelPreview.AutoEllipsis = true;
        labelPreview.TabIndex = 5;
        //
        // groupBoxCategory
        //
        groupBoxCategory.Controls.Add(labelCategory);
        groupBoxCategory.Controls.Add(comboBoxCategory);
        groupBoxCategory.Location = new Point(380, 80);
        groupBoxCategory.Name = "groupBoxCategory";
        groupBoxCategory.Size = new Size(250, 172);
        groupBoxCategory.Text = "カテゴリ";
        groupBoxCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxCategory.Dock = DockStyle.None;
        groupBoxCategory.TabStop = false;
        groupBoxCategory.TabIndex = 3;
        //
        // labelCategory
        //
        labelCategory.Location = new Point(20, 32);
        labelCategory.Name = "labelCategory";
        labelCategory.Size = new Size(180, 22);
        labelCategory.Text = "分類を選択";
        labelCategory.TabIndex = 0;
        //
        // comboBoxCategory
        //
        comboBoxCategory.Location = new Point(20, 64);
        comboBoxCategory.Name = "comboBoxCategory";
        comboBoxCategory.Size = new Size(210, 23);
        comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxCategory.FormattingEnabled = true;
        comboBoxCategory.Items.AddRange(new object[] { "通常", "優先", "保留" });
        comboBoxCategory.TabIndex = 1;
        //
        // groupBoxOptions
        //
        groupBoxOptions.Controls.Add(checkBoxNotify);
        groupBoxOptions.Controls.Add(checkBoxArchive);
        groupBoxOptions.Location = new Point(654, 132);
        groupBoxOptions.Name = "groupBoxOptions";
        groupBoxOptions.Size = new Size(270, 140);
        groupBoxOptions.Text = "オプション（配置例）";
        groupBoxOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        groupBoxOptions.Dock = DockStyle.None;
        groupBoxOptions.TabStop = false;
        groupBoxOptions.TabIndex = 4;
        //
        // checkBoxNotify
        //
        checkBoxNotify.Location = new Point(20, 34);
        checkBoxNotify.Name = "checkBoxNotify";
        checkBoxNotify.Size = new Size(230, 26);
        checkBoxNotify.Text = "通知を有効にする";
        checkBoxNotify.UseVisualStyleBackColor = true;
        checkBoxNotify.TabIndex = 0;
        //
        // checkBoxArchive
        //
        checkBoxArchive.Location = new Point(20, 76);
        checkBoxArchive.Name = "checkBoxArchive";
        checkBoxArchive.Size = new Size(230, 26);
        checkBoxArchive.Text = "履歴を残す";
        checkBoxArchive.UseVisualStyleBackColor = true;
        checkBoxArchive.TabIndex = 1;
        //
        // ModeAView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        AutoScroll = true;
        AutoScrollMinSize = new Size(940, 350);
        Controls.Add(labelModeTitle);
        Controls.Add(labelLayoutHint);
        Controls.Add(groupBoxInput);
        Controls.Add(groupBoxCategory);
        Controls.Add(groupBoxOptions);
        Size = new Size(990, 470);
        Name = "ModeAView";
        ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
        groupBoxInput.ResumeLayout(false);
        groupBoxInput.PerformLayout();
        groupBoxCategory.ResumeLayout(false);
        groupBoxCategory.PerformLayout();
        groupBoxOptions.ResumeLayout(false);
        groupBoxOptions.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelModeTitle;
    private Label labelLayoutHint;
    private GroupBox groupBoxInput;
    private Label labelName;
    private TextBox textBoxName;
    private Label labelQuantity;
    private NumericUpDown numericQuantity;
    private Button buttonPreview;
    private Label labelPreview;
    private GroupBox groupBoxCategory;
    private Label labelCategory;
    private ComboBox comboBoxCategory;
    private GroupBox groupBoxOptions;
    private CheckBox checkBoxNotify;
    private CheckBox checkBoxArchive;
}
