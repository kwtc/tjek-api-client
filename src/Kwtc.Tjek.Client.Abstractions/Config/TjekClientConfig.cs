namespace Kwtc.Tjek.Client.Abstractions.Config;

public class TjekClientConfig
{
    public static string SectionName => "TjekClientConfig";
    
    public string ApiKey { get; set; } = string.Empty;
}
