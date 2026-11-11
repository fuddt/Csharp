namespace WinFormsReusableParts.Models;

internal sealed class ModeModel : IReadOnlyModeModel
{
    public string LastEInput { get; private set; } = string.Empty;

    internal void SetLastEInput(string input)
    {
        if (LastEInput != input)
        {
            LastEInput = input;
        }
    }
}
