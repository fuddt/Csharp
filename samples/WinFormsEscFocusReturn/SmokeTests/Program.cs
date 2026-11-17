using System.Reflection;
using WinFormsEscFocusReturn.Forms;

namespace SmokeTests;

internal static class Program
{
    private const int WmKeyDown = 0x0100;

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

            // 1. デフォルト（Owner あり：Show(this)）で小さいFormを開く
            var useOwner = Find<CheckBox>(main, "checkBoxUseOwner");
            var openButton = Find<Button>(main, "buttonOpenSmallForm");
            Require(useOwner.Checked, "Owner 指定モードが初期状態で有効");

            openButton.PerformClick();
            Application.DoEvents();

            var smallForm = Application.OpenForms.OfType<SmallToolForm>().Single();
            Require(!smallForm.Modal, "小さいFormはモードレス（Show）で開かれる");
            Require(ReferenceEquals(smallForm.Owner, main), "Show(this) により Owner がメインFormになる");
            Require(smallForm.CancelButton is null, "Esc で閉じないように CancelButton は未設定");
            Require(smallForm.Width < main.Width && smallForm.Height < main.Height, "小さいFormはメインFormより小さい");
            Require(!useOwner.Enabled, "小さいFormが開いている間は Owner 切り替えを無効化");

            // 重複クリックしても新しいFormを増やさない
            openButton.PerformClick();
            Application.DoEvents();
            Require(Application.OpenForms.OfType<SmallToolForm>().Count() == 1, "ボタン再押下で重複生成しない");

            // 2. TextBox にフォーカスがある状態で Esc を処理しても閉じない
            var subInput = Find<TextBox>(smallForm, "textBoxSubInput");
            subInput.Focus();
            subInput.Text = "編集中メモ";
            Application.DoEvents();

            bool handledFromTextBox = InvokeProcessCmdKey(smallForm, Keys.Escape);
            Application.DoEvents();
            Require(handledFromTextBox, "Esc キーは ProcessCmdKey で処理済み (true) を返す");
            Require(!smallForm.IsDisposed && smallForm.Visible, "Esc を押しても小さいFormは閉じない");
            Require(subInput.Text == "編集中メモ", "小さいForm内の入力状態が維持される");
            if (Form.ActiveForm is not null)
            {
                Require(ReferenceEquals(Form.ActiveForm, main), "フォアグラウンド環境ではメインFormがアクティブになる");
            }

            // 3. Button にフォーカスがある状態で Esc を処理しても閉じない
            var subAction = Find<Button>(smallForm, "buttonSubAction");
            subAction.Focus();
            subAction.PerformClick();
            Application.DoEvents();
            Require(subAction.Text.Contains("1回"), "小さいForm内の操作が機能する");

            bool handledFromButton = InvokeProcessCmdKey(smallForm, Keys.Escape);
            Application.DoEvents();
            Require(handledFromButton, "ボタン上から Esc を押しても ProcessCmdKey が捕捉する");
            Require(!smallForm.IsDisposed && smallForm.Visible, "ボタン上から Esc を押しても小さいFormは閉じない");
            if (Form.ActiveForm is not null)
            {
                Require(ReferenceEquals(Form.ActiveForm, main), "Esc 後はメインFormがアクティブになる");
            }

            // 4. Esc 以外のキー（Enter）は奪わない
            bool handledEnter = InvokeProcessCmdKey(smallForm, Keys.Enter);
            Require(!handledEnter, "Esc 以外のキーは ProcessCmdKey で横取りしない");

            // 5. 「閉じる」ボタンで閉じたあと、Owner なしモード（Show()）でも戻れることを確認
            Find<Button>(smallForm, "buttonClose").PerformClick();
            Application.DoEvents();
            Require(smallForm.IsDisposed, "閉じるボタンで小さいFormが破棄される");
            Require(useOwner.Enabled, "閉じた後は Owner 切り替えが再び有効になる");

            useOwner.Checked = false;
            openButton.PerformClick();
            Application.DoEvents();

            var unownedSmallForm = Application.OpenForms.OfType<SmallToolForm>().Single();
            Require(unownedSmallForm.Owner is null, "Owner なしモードでは Owner が null");
            bool handledUnowned = InvokeProcessCmdKey(unownedSmallForm, Keys.Escape);
            Application.DoEvents();
            Require(handledUnowned, "Owner なしモードでも Esc キーを処理する");
            Require(!unownedSmallForm.IsDisposed && unownedSmallForm.Visible, "Owner なしモードでも Esc で閉じない");
            if (Form.ActiveForm is not null)
            {
                Require(ReferenceEquals(Form.ActiveForm, main), "Owner なしモードでもメインFormがアクティブになる");
            }

            unownedSmallForm.Close();
            main.Close();
            Require(main.IsDisposed, "終了時にメインFormが破棄される");

            Console.WriteLine("PASS: modeless Show(this)/Show(), Esc focus return without closing via ProcessCmdKey, single-instance guard, and clean disposal.");
            return 0;
        }
        catch (Exception error)
        {
            Console.Error.WriteLine(error);
            return 1;
        }
    }

    private static bool InvokeProcessCmdKey(SmallToolForm form, Keys keyData)
    {
        MethodInfo method = typeof(SmallToolForm).GetMethod(
            "ProcessCmdKey",
            BindingFlags.Instance | BindingFlags.NonPublic)
            ?? throw new InvalidOperationException("ProcessCmdKey method was not found.");

        Message msg = Message.Create(form.Handle, WmKeyDown, (IntPtr)keyData, IntPtr.Zero);
        object?[] args = [msg, keyData];
        return (bool)(method.Invoke(form, args) ?? false);
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
