namespace Kwtc.Tjek.Client;

public class ClientConfig
{
    public static string SectionName => "TjekClientConfig";
    
    public string ApiKey { get; set; } = string.Empty;
}
