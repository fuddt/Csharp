using WinFormsReusableParts.Contracts;
using WinFormsReusableParts.Forms;
using WinFormsReusableParts.Views.Pages;
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

            UserControl? finalPage = null;
            WithSettingsDialog(main, dialog => finalPage = ExercisePages(dialog));
            Require(finalPage is { IsDisposed: true }, "Closing the dialog disposes its last page");

            WithSettingsDialog(main, dialog =>
            {
                var host = Find<Panel>(dialog, "panelPageHost");
                var pageE = SelectPage<PageEView>(dialog, host, 'E');
                Require(Find<TextBox>(pageE, "textBoxLastEInput").Text == "", "A new dialog starts a new Model session");
            });

            Console.WriteLine("PASS: modal launch and close, A-E layouts, 25 repeated switches, current-page snapshots, independent instances, E restore and reset, and failed-switch recovery.");
            return 0;
        }
        catch (Exception error)
        {
            Console.Error.WriteLine(error);
            return 1;
        }
    }

    private static UserControl ExercisePages(ModeSelectForm dialog)
    {
        var host = Find<Panel>(dialog, "panelPageHost");
        var pageA = (PageAView)CurrentPage(host);
        var xInA = Find<PartXControl>(pageA, "partX");
        var yInA = Find<PartYControl>(pageA, "partY");
        var previewInA = Find<CheckBox>(xInA, "checkBoxShowPreview");
        var validateInA = Find<CheckBox>(yInA, "checkBoxValidateInput");
        var result = Find<TextBox>(dialog, "textBoxResult");
        var getChecked = Find<Button>(dialog, "buttonGetCheckedTexts");

        Require(Find<RadioButton>(dialog, "radioButtonA").Checked, "A is selected on open");
        Require(pageA.Controls.Count == 2 && xInA.Top < yInA.Top, "A has X above Y");
        Find<RadioButton>(dialog, "radioButtonA").Checked = true;
        Require(ReferenceEquals(pageA, CurrentPage(host)), "Reselecting A keeps the same page");
        previewInA.Checked = true;
        validateInA.Checked = true;
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual(new[] { previewInA.Text, validateInA.Text }), "A gathers selected items from X and Y");
        var positionOfXInA = xInA.Location;

        // Inject a failure after the candidate has already been attached. The dialog must roll it back.
        UserControl? rejectedPage = null;
        ControlEventHandler rejectAdd = (_, e) =>
        {
            if (e.Control is PageBView candidate)
            {
                rejectedPage = candidate;
                throw new InvalidOperationException("injected page attach failure");
            }
        };
        host.ControlAdded += rejectAdd;
        try
        {
            Find<RadioButton>(dialog, "radioButtonB").Checked = true;
        }
        finally
        {
            host.ControlAdded -= rejectAdd;
        }
        Require(rejectedPage is { IsDisposed: true }, "Failed page candidate is disposed");
        Require(ReferenceEquals(pageA, CurrentPage(host)) && !pageA.IsDisposed && previewInA.Checked, "Failed switch keeps A and its state");
        Require(Find<RadioButton>(dialog, "radioButtonA").Checked && !Find<RadioButton>(dialog, "radioButtonB").Checked, "Failed switch restores the selection");
        Require(result.Text.Contains("injected page attach failure", StringComparison.Ordinal), "Failed switch reports the error");

        var pageB = SelectPage<PageBView>(dialog, host, 'B');
        var xInB = Find<PartXControl>(pageB, "partX");
        var zInB = Find<PartZControl>(pageB, "partZ");
        Require(pageB.Controls.Count == 2 && xInB.Top < zInB.Top, "B has X above Z");
        Require(xInA.GetType() == xInB.GetType() && !ReferenceEquals(xInA, xInB), "A and B reuse the type with separate instances");
        Require(xInA.IsDisposed && yInA.IsDisposed && previewInA.IsDisposed, "Switch disposes A's parts and checkboxes");
        Require(result.Text == "", "Switch clears the previous page's displayed result");
        var previewInB = Find<CheckBox>(xInB, "checkBoxShowPreview");
        Require(!previewInB.Checked, "A's X selection does not carry into B");
        previewInB.Text = "Bのプレビュー項目";
        previewInB.Checked = true;
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual(new[] { previewInB.Text }), "B returns only the current checkbox Text");
        var snapshot = ((ICheckedTextPage)pageB).GetCheckedTexts();
        previewInB.Checked = false;
        getChecked.PerformClick();
        Require(result.Text == "チェックされた項目はありません。" && pageB.GetCheckedTexts().Count == 0, "Empty result stays empty");
        Require(snapshot.SequenceEqual(new[] { previewInB.Text }), "The previous snapshot stays independent of later changes");

        var pageC = SelectPage<PageCView>(dialog, host, 'C');
        var xInC = Find<PartXControl>(pageC, "partX");
        var wInC = Find<PartWControl>(pageC, "partW");
        var guides = Find<CheckBox>(wInC, "checkBoxShowGuides");
        var actualSize = Find<CheckBox>(xInC, "checkBoxUseActualSize");
        Require(pageC.Controls.Count == 2 && xInC.Top > wInC.Top && xInC.Location != positionOfXInA, "C places X below W");
        guides.Checked = true;
        actualSize.Checked = true;
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual(new[] { guides.Text, actualSize.Text }), "C gathers W and the relocated X");

        var pageD = SelectPage<PageDView>(dialog, host, 'D');
        Require(pageD.Controls.Count == 2 && Find<PartYControl>(pageD, "partY").Top < Find<PartZControl>(pageD, "partZ").Top, "D has Y above Z");

        var firstE = SelectPage<PageEView>(dialog, host, 'E');
        var input = Find<TextBox>(firstE, "textBoxLastEInput");
        Require(input.Text == "", "E starts empty");
        input.Text = "Hello";
        Find<CheckBox>(firstE, "checkBoxShowPreview").Checked = true;
        getChecked.PerformClick();
        Require(result.Lines.SequenceEqual(new[] { Find<CheckBox>(firstE, "checkBoxShowPreview").Text }), "E gathers X while keeping text input separate");

        var nextA = SelectPage<PageAView>(dialog, host, 'A');
        Require(!ReferenceEquals(pageA, nextA) && nextA.GetCheckedTexts().Count == 0, "Returning to A recreates its checkboxes");
        var nextE = SelectPage<PageEView>(dialog, host, 'E');
        Require(!ReferenceEquals(firstE, nextE) && Find<TextBox>(nextE, "textBoxLastEInput").Text == "Hello", "New E view restores the last input");
        Require(nextE.GetCheckedTexts().Count == 0, "Returning to E resets its checks");
        Find<TextBox>(nextE, "textBoxLastEInput").Clear();
        SelectPage<PageDView>(dialog, host, 'D');
        var clearedE = SelectPage<PageEView>(dialog, host, 'E');
        Require(Find<TextBox>(clearedE, "textBoxLastEInput").Text == "", "Clearing E replaces the stored value");
        Find<TextBox>(clearedE, "textBoxLastEInput").Text = "このダイアログで保持";

        for (int round = 0; round < 5; round++)
        {
            SelectPage<PageAView>(dialog, host, 'A');
            SelectPage<PageBView>(dialog, host, 'B');
            SelectPage<PageCView>(dialog, host, 'C');
            SelectPage<PageDView>(dialog, host, 'D');
            var pageE = SelectPage<PageEView>(dialog, host, 'E');
            Require(Find<TextBox>(pageE, "textBoxLastEInput").Text == "このダイアログで保持", "E keeps its value across repeated switches");
        }

        dialog.Size = dialog.MinimumSize;
        Application.DoEvents();
        var lastPage = CurrentPage(host);
        Require(lastPage.VerticalScroll.Visible, "Page content can scroll at the minimum size");
        return lastPage;
    }

    private static void WithSettingsDialog(MainForm main, Action<ModeSelectForm> exercise)
    {
        Form? openedForm = null;
        Exception? failure = null;
        using var timer = new System.Windows.Forms.Timer { Interval = 40 };
        // ShowDialog has a nested message loop. Run the checks inside it on the same STA thread.
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
                Require(openedForm is ModeSelectForm { Modal: true } && openedForm.Owner == main, "Main opens the expected modal child");
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
        Require(openedForm is ModeSelectForm { IsDisposed: true }, "Main disposes the dialog after ShowDialog");
    }

    private static T SelectPage<T>(ModeSelectForm dialog, Panel host, char mode) where T : UserControl
    {
        var previous = CurrentPage(host);
        int disposeCount = 0;
        previous.Disposed += (_, _) => disposeCount++;
        Find<RadioButton>(dialog, $"radioButton{mode}").Checked = true;
        var current = CurrentPage(host);
        Require(previous.IsDisposed && disposeCount == 1, $"Switching to {mode} disposes the old page once");
        Require(current is T && current.Dock == DockStyle.Fill && !current.IsDisposed, $"The host contains the live page for {mode}");
        return (T)current;
    }

    private static UserControl CurrentPage(Panel host)
    {
        Require(host.Controls.Count == 1, "Exactly one page is in the host");
        return (UserControl)host.Controls[0];
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
