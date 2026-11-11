using WinFormsDynamicUi;
using WinFormsDynamicUi.Views;

namespace SmokeTests;

internal static class Program
{
    [STAThread]
    private static int Main()
    {
        try
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var form = new MainForm();
            form.Show();
            Application.DoEvents();

            var center = Find<Panel>(form, "panelCenter");
            var top = Find<GroupBox>(form, "groupBoxTop");
            var bottom = Find<GroupBox>(form, "groupBoxBottom");
            var commonMemo = Find<TextBox>(form, "textBoxCommonMemo");
            commonMemo.Text = "共通入力を保持";
            Require(center.Dock == DockStyle.Fill && !center.AutoScroll, "中央Panelの設定");
            Require(top.Dock == DockStyle.Top && bottom.Dock == DockStyle.Bottom, "上下の共通領域");
            Require(top.Controls.OfType<RadioButton>().Count() == 6, "6つのモード選択");
            Require(CurrentView(center) is ModeAView, "初期モードA");

            var initialView = CurrentView(center);
            Find<RadioButton>(form, "radioButtonA").Checked = true;
            Require(ReferenceEquals(initialView, CurrentView(center)), "同じ選択では再生成しない");
            ExerciseMode(initialView);
            int creations = 1;

            // A→B→C→D→E→F→Aを5周。外れたRadioButtonのイベントによる二重生成も検出する。
            for (int cycle = 0; cycle < 5; cycle++)
            {
                foreach (char mode in "BCDEFA")
                {
                    var previous = CurrentView(center);
                    Control[] previousChildren = Descendants(previous).ToArray();
                    Find<RadioButton>(form, $"radioButton{mode}").Checked = true;
                    Application.DoEvents();

                    var current = CurrentView(center);
                    Require(previous.IsDisposed, $"{mode}: 古いViewをDispose");
                    Require(previousChildren.All(control => control.IsDisposed), $"{mode}: 子部品もDispose");
                    Require(!ReferenceEquals(previous, current), $"{mode}: 新しいインスタンス");
                    Require(current.GetType().Name == $"Mode{mode}View", $"{mode}: 対応するViewを表示");
                    Require(current.Dock == DockStyle.Fill && current.AutoScroll, $"{mode}: Viewの配置とスクロール設定");
                    Require(!top.IsDisposed && !bottom.IsDisposed, $"{mode}: 共通領域は継続");
                    Require(ReferenceEquals(top, Find<GroupBox>(form, "groupBoxTop")), $"{mode}: 上部の実体を保持");
                    Require(ReferenceEquals(bottom, Find<GroupBox>(form, "groupBoxBottom")), $"{mode}: 下部の実体を保持");
                    Require(commonMemo.Text == "共通入力を保持", $"{mode}: 共通入力は保持");
                    creations++;
                    Require(Find<Label>(form, "labelCurrentMode").Text.Contains($"生成回数: {creations} "), $"{mode}: 1回の選択で1回生成");

                    GroupBox[] groups = current.Controls.OfType<GroupBox>().ToArray();
                    Require(groups.Length >= 2, $"{mode}: 専用GroupBox");
                    Require(groups.All(group => group.Dock == DockStyle.None && group.Anchor == (AnchorStyles.Top | AnchorStyles.Left)), $"{mode}: 自由配置の設定");
                    if (mode == 'A')
                    {
                        Require(Find<TextBox>(current, "textBoxName").Text == "サンプル", "戻ったモードの入力を初期化");
                    }

                    if (cycle == 0)
                    {
                        ExerciseMode(current);
                        var originalSize = form.Size;
                        form.Size = form.MinimumSize;
                        Application.DoEvents();
                        Require(current.HorizontalScroll.Visible && current.VerticalScroll.Visible, $"{mode}: 縮小時に縦横スクロール可能");
                        form.Size = originalSize;
                        Application.DoEvents();
                    }
                }
            }

            var lastView = CurrentView(center);
            form.Close();
            Require(form.IsDisposed && lastView.IsDisposed, "フォーム終了時に最後のViewもDispose");
            Console.WriteLine($"PASS: 6 modes, 30 switches, {creations} creations, child disposal, common state, reset, scrolling, local actions, and close disposal.");
            return 0;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine(exception);
            return 1;
        }
    }

    private static UserControl CurrentView(Panel center)
    {
        Require(center.Controls.Count == 1, "中央のViewは常に1つ");
        return (UserControl)center.Controls[0];
    }

    private static T Find<T>(Control root, string name) where T : Control
    {
        return root.Controls.Find(name, true).OfType<T>().Single();
    }

    private static IEnumerable<Control> Descendants(Control root)
    {
        foreach (Control child in root.Controls)
        {
            yield return child;
            foreach (Control descendant in Descendants(child))
            {
                yield return descendant;
            }
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException($"FAIL: {message}");
        }
    }

    private static void ExerciseMode(UserControl view)
    {
        switch (view)
        {
            case ModeAView:
                Find<TextBox>(view, "textBoxName").Text = "テスト";
                Find<NumericUpDown>(view, "numericQuantity").Value = 3;
                Find<ComboBox>(view, "comboBoxCategory").SelectedIndex = 2;
                Find<Button>(view, "buttonPreview").PerformClick();
                Require(Find<Label>(view, "labelPreview").Text == "テスト / 3 個 / 保留", "A: 入力内容を表示");
                break;
            case ModeBView:
                Find<NumericUpDown>(view, "numericThreshold").Value = 55;
                Find<Button>(view, "buttonFilter").PerformClick();
                var results = Find<ListBox>(view, "listBoxResults");
                Require(results.Items.Cast<string>().SequenceEqual(new[] { "センサーB: 55", "センサーC: 80" }), "B: 以上の境界を含む絞り込み");
                Find<RadioButton>(view, "radioButtonAtMost").Checked = true;
                Find<Button>(view, "buttonFilter").PerformClick();
                Require(results.Items.Cast<string>().SequenceEqual(new[] { "センサーA: 25", "センサーB: 55" }), "B: 以下の境界を含む絞り込み");
                Find<NumericUpDown>(view, "numericThreshold").Value = 0;
                Find<Button>(view, "buttonFilter").PerformClick();
                Require(results.Items.Count == 0, "B: 該当なし");
                break;
            case ModeCView:
                Find<NumericUpDown>(view, "numericX").Value = 12.5M;
                Find<NumericUpDown>(view, "numericY").Value = -4.5M;
                Find<Button>(view, "buttonApply").PerformClick();
                Require(Find<Label>(view, "labelCoordinates").Text == $"X = {12.5M:F1}, Y = {-4.5M:F1}", "C: 座標を表示");
                Find<TrackBar>(view, "trackBarAngle").Value = 180;
                Require(Find<Label>(view, "labelAngle").Text == "角度: 180°", "C: 角度を表示");
                break;
            case ModeDView:
                var jobs = Find<CheckedListBox>(view, "checkedListBoxJobs");
                Require(jobs.CheckedItems.Count == 1, "D: 初期選択");
                Find<Button>(view, "buttonSelectAll").PerformClick();
                Find<Button>(view, "buttonRun").PerformClick();
                Require(jobs.CheckedItems.Count == 3 && Find<TextBox>(view, "textBoxOutput").Lines.Length == 3, "D: 全選択して表示");
                for (int index = 0; index < jobs.Items.Count; index++)
                {
                    jobs.SetItemChecked(index, false);
                }
                Find<Button>(view, "buttonRun").PerformClick();
                Require(Find<TextBox>(view, "textBoxOutput").Text == "項目を選択してください。", "D: 未選択時の表示");
                break;
            case ModeEView:
                Find<RichTextBox>(view, "richTextBoxNote").Text = "メモのテスト";
                Find<CheckBox>(view, "checkBoxShowTitle").Checked = false;
                Find<Button>(view, "buttonPreview").PerformClick();
                Require(Find<Label>(view, "labelNotePreview").Text == "メモのテスト", "E: 見出しなし");
                Find<CheckBox>(view, "checkBoxShowTitle").Checked = true;
                Find<Button>(view, "buttonPreview").PerformClick();
                Require(Find<Label>(view, "labelNotePreview").Text.StartsWith("メモの内容") && Find<Label>(view, "labelNotePreview").Text.EndsWith("メモのテスト"), "E: 見出しあり");
                break;
            case ModeFView:
                Find<ComboBox>(view, "comboBoxColor").SelectedIndex = 1;
                Find<Button>(view, "buttonApplyColor").PerformClick();
                var swatch = Find<Panel>(view, "panelSwatch");
                Require(swatch.BackColor == Color.SeaGreen, "F: 色を反映");
                Find<NumericUpDown>(view, "numericWidth").Value = 240;
                Find<NumericUpDown>(view, "numericHeight").Value = 120;
                Find<Button>(view, "buttonApplySize").PerformClick();
                Require(swatch.Size == new Size(240, 120), "F: サイズを反映");
                break;
            default:
                throw new InvalidOperationException("未検証のViewです。");
        }
    }
}
