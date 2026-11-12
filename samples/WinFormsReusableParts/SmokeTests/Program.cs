using WinFormsReusableParts.Forms;
using WinFormsReusableParts.Views.Parts;

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

            using var main = new MainForm();
            main.Show();
            Application.DoEvents();

            WithSettingsDialog(main, dialog => ExerciseSettingsDialog(dialog));

            Console.WriteLine("PASS: modal launch and close, A-E fixed-part visibility toggles, slot layouts, 25 repeated switches, current-visible snapshots, shared state persistence, and E text preservation.");
            return 0;
        }
        catch (Exception error)
        {
            Console.Error.WriteLine(error);
            return 1;
        }
    }

    private static void ExerciseSettingsDialog(ModeSelectForm dialog)
    {
        var host = Find<Panel>(dialog, "panelPageHost");
        var partX = Find<PartXControl>(host, "partX");
        var partY = Find<PartYControl>(host, "partY");
        var partZ = Find<PartZControl>(host, "partZ");
        var partW = Find<PartWControl>(host, "partW");
        var partE = Find<PartEControl>(host, "partE");

        var checkPreview = Find<CheckBox>(partX, "checkBoxShowPreview");
        var checkValidate = Find<CheckBox>(partY, "checkBoxValidateInput");
        var checkTime = Find<CheckBox>(partZ, "checkBoxIncludeTime");
        var checkGuide = Find<CheckBox>(partW, "checkBoxShowGuides");
        var textE = Find<TextBox>(partE, "textBoxLastEInput");

        var result = Find<TextBox>(dialog, "textBoxResult");
        var getChecked = Find<Button>(dialog, "buttonGetCheckedTexts");

        // 1. 初期状態（モードA）
        Require(Find<RadioButton>(dialog, "radioButtonA").Checked, "A is selected on open");
        Require(partX.Visible && partY.Visible && !partZ.Visible && !partW.Visible && !partE.Visible, "A shows X and Y only");
        Require(partX.Top < partY.Top, "A layout puts X above Y");

        // AでXとYにチェックを入れる
        checkPreview.Checked = true;
        checkValidate.Checked = true;
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual([checkPreview.Text, checkValidate.Text]), "A gathers checked texts from X and Y");

        // 2. モードBへ切り替え
        Find<RadioButton>(dialog, "radioButtonB").Checked = true;
        Require(partX.Visible && partZ.Visible && !partY.Visible && !partW.Visible && !partE.Visible, "B shows X and Z only");
        Require(partX.Top < partZ.Top, "B layout puts X above Z");
        Require(checkPreview.Checked, "Shared setting: X preview check persists when switching to B");
        Require(result.Text == "", "Switching modes clears the previous result");

        // Bで取得: 非表示のYは集約されず、表示中のXのみ取得される
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual([checkPreview.Text]), "B gathers only visible X (hidden Y is excluded)");

        // BでZもチェック
        checkTime.Checked = true;
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual([checkPreview.Text, checkTime.Text]), "B gathers X and Z");

        // 3. モードCへ切り替え (Wが上、Xが下)
        Find<RadioButton>(dialog, "radioButtonC").Checked = true;
        Require(partW.Visible && partX.Visible && !partY.Visible && !partZ.Visible && !partE.Visible, "C shows W and X only");
        Require(partW.Top < partX.Top, "C layout puts W above X");
        checkGuide.Checked = true;
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual([checkGuide.Text, checkPreview.Text]), "C gathers W and X in top-down display order");

        // 4. モードDへ切り替え (Yが上、Zが下)
        Find<RadioButton>(dialog, "radioButtonD").Checked = true;
        Require(partY.Visible && partZ.Visible && !partX.Visible && !partW.Visible && !partE.Visible, "D shows Y and Z only");
        Require(partY.Top < partZ.Top, "D layout puts Y above Z");
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual([checkValidate.Text, checkTime.Text]), "D gathers Y and Z (both persisted from earlier checks)");

        // 5. モードEへ切り替え (TextBoxが上、Xが下)
        Find<RadioButton>(dialog, "radioButtonE").Checked = true;
        Require(partE.Visible && partX.Visible && !partY.Visible && !partZ.Visible && !partW.Visible, "E shows E and X only");
        Require(partE.Top < partX.Top, "E layout puts E (TextBox) above X");
        textE.Text = "Hello WinForms Persisted";
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual([checkPreview.Text]), "E gathers only X check box (TextBox is text input, not check)");

        // 6. EからAへ切り替えて再度Eに戻る
        Find<RadioButton>(dialog, "radioButtonA").Checked = true;
        Require(partX.Visible && partY.Visible && !partE.Visible, "A hides E");
        Find<RadioButton>(dialog, "radioButtonE").Checked = true;
        Require(partE.Visible && textE.Text == "Hello WinForms Persisted", "E text persists across mode transitions without recreation");

        // 7. 25回の連続切り替えストレステスト（全モードを5周）
        for (int round = 0; round < 5; round++)
        {
            Find<RadioButton>(dialog, "radioButtonA").Checked = true;
            Find<RadioButton>(dialog, "radioButtonB").Checked = true;
            Find<RadioButton>(dialog, "radioButtonC").Checked = true;
            Find<RadioButton>(dialog, "radioButtonD").Checked = true;
            Find<RadioButton>(dialog, "radioButtonE").Checked = true;
        }
        Require(textE.Text == "Hello WinForms Persisted", "E text persists across 25 repeated mode switches");
        Require(host.Controls.Count == 5, "Host retains exactly the 5 pre-created part controls (no leaks)");

        // 8. 最小サイズでのスクロール確認
        dialog.Size = dialog.MinimumSize;
        Application.DoEvents();
        Require(host.AutoScroll, "Host panel has AutoScroll enabled for compact windows");
    }

    private static void WithSettingsDialog(MainForm main, Action<ModeSelectForm> exercise)
    {
        Form? openedForm = null;
        Exception? failure = null;
        using var timer = new System.Windows.Forms.Timer { Interval = 40 };

        timer.Tick += (_, _) =>
        {
            openedForm = Application.OpenForms.Cast<Form>().FirstOrDefault(form => form != main);
            if (openedForm is null)
            {
                return;
            }

            timer.Stop();
            try
            {
                Require(openedForm is ModeSelectForm { Modal: true } && openedForm.Owner == main, "Main opens modal child ModeSelectForm");
                var dialog = (ModeSelectForm)openedForm;
                Require(dialog.Width < main.Width && dialog.Height < main.Height, "The settings dialog is smaller than the main window");
                exercise(dialog);
                Find<Button>(dialog, "buttonClose").PerformClick();
            }
            catch (Exception error)
            {
                failure = error;
            }
            finally
            {
                if (openedForm.DialogResult == DialogResult.None)
                {
                    openedForm.Close();
                }
            }
        };

        timer.Start();
        Find<Button>(main, "buttonOpenSettings").PerformClick();
        timer.Stop();

        if (failure is not null)
        {
            throw new InvalidOperationException("Settings dialog smoke test failed.", failure);
        }
        Require(openedForm is ModeSelectForm { IsDisposed: true }, "Main disposes dialog after ShowDialog completes");
    }

    private static T Find<T>(Control root, string name) where T : Control
    {
        return root.Controls.Find(name, searchAllChildren: true).OfType<T>().Single();
    }

    private static void Require(bool condition, string expectation)
    {
        if (!condition)
        {
            throw new InvalidOperationException($"FAIL: {expectation}");
        }
    }
}
