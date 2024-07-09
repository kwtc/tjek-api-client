using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Links
{
    [JsonPropertyName("webshop")]
    public string? Webshop { get; set; }
}
