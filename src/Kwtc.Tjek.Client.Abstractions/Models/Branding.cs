using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Branding
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
    
    [JsonPropertyName("website")]
    public string? Website { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("color")]
    public string Color { get; set; } = default!;
    
    [JsonPropertyName("logo")]
    public string Logo { get; set; } = default!;
}
