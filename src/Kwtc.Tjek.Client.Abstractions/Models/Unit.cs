using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Unit
{
    [JsonPropertyName("si")]
    public Si Si { get; set; } = default!;

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = default!;
}
