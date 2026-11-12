using WinFormsReusableParts.Models;

namespace WinFormsReusableParts.Controllers;

internal sealed class ModeController(ModeModel model)
{
    internal void ChangeEInput(string input)
    {
        model.SetLastEInput(input);
    }
}
