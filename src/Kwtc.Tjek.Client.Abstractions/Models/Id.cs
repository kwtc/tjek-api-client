using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Id
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("provider")]
    public string Provider { get; set; } = default!;

    [JsonPropertyName("value")]
    public string Value { get; set; } = default!;
}
