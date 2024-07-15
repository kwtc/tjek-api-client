using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class CatalogPageDecoration
{
    [JsonPropertyName("page_number")]
    public long PageNumber { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("website_link")]
    public string? WebsiteLink { get; set; }

    [JsonPropertyName("website_link_title")]
    public string? WebsiteLinkTitle { get; set; }

    [JsonPropertyName("hotspots")]
    public CatalogPageDecorationHotspot[]? Hotspots { get; set; }
}
