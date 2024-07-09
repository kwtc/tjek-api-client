using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Pageflip
{
    [JsonPropertyName("logo")]
    public string Logo { get; set; } = default!;

    [JsonPropertyName("color")]
    public string Color { get; set; } = default!;
}
