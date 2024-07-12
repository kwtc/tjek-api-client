namespace Kwtc.Tjek.Client;

public static class StringExtensions
{
    public static string ToValidUri(this string input)
    {
        // TODO: Improve this method or find alternative
        
        var str = input;
        str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-zA-Z0-9\s-æøåÆØÅ?&=]", "");
        str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim();

        return Uri.EscapeDataString(str);
    }
}
