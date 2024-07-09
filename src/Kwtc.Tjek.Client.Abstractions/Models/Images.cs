using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Images
{
    [JsonPropertyName("thumb")]
    public string Thumb { get; set; } = default!;

    [JsonPropertyName("view")]
    public string View { get; set; } = default!;

    [JsonPropertyName("zoom")]
    public string Zoom { get; set; } = default!;
}
