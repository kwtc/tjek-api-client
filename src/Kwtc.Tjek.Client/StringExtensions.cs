namespace Kwtc.Tjek.Client;

public static class StringExtensions
{
    public static string ToValidUri(this string input)
    {
        var str = input;
        str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-zA-Z0-9\s-æøåÆØÅ]", "");
        str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim();

        return Uri.EscapeDataString(str);
    }
}
