using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Dimensions
{
    [JsonPropertyName("width")]
    public decimal Width { get; set; }

    [JsonPropertyName("height")]
    public decimal Height { get; set; }
}
