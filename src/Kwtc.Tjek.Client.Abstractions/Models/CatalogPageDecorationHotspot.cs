using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class CatalogPageDecorationHotspot
{
    [JsonPropertyName("x1")]
    public long X1 { get; set; }

    [JsonPropertyName("x2")]
    public long X2 { get; set; }

    [JsonPropertyName("y1")]
    public long Y1 { get; set; }

    [JsonPropertyName("y2")]
    public long Y2 { get; set; }

    [JsonPropertyName("rotate")]
    public long Rotate { get; set; }

    [JsonPropertyName("embed_link")]
    public string EmbedLink { get; set; } = default!;

    [JsonPropertyName("link")]
    public string Link { get; set; } = default!;
}
