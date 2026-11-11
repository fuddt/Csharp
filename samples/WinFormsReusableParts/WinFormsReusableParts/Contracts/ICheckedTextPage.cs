namespace WinFormsReusableParts.Contracts;

public interface ICheckedTextPage
{
    /// <summary>このページでチェックされている項目の表示文字列を、呼び出し時点の一覧として返します。</summary>
    IReadOnlyList<string> GetCheckedTexts();
}
