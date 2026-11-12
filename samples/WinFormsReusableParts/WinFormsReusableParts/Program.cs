using WinFormsReusableParts.Forms;

namespace WinFormsReusableParts;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
