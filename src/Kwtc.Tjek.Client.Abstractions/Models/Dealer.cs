using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Dealer
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("ern")]
    public string Ern { get; set; } = default!;

    [JsonPropertyName("markets")]
    public IEnumerable<Market> Markets { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("website")]
    public string Website { get; set; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = default!;

    [JsonPropertyName("logo")]
    public string Logo { get; set; } = default!;

    [JsonPropertyName("color")]
    public string Color { get; set; } = default!;

    [JsonPropertyName("pageflip")]
    public Pageflip Pageflip { get; set; } = default!;

    [JsonPropertyName("country")]
    public Country Country { get; set; } = default!;

    [JsonPropertyName("description_markdown")]
    public string DescriptionMarkdown { get; set; } = default!;

    [JsonPropertyName("favorite_count")]
    public long FavoriteCount { get; set; }

    [JsonPropertyName("is_incito_supported")]
    public bool IsIncitoSupported { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; } = default!;

    [JsonPropertyName("category_ids")]
    public IEnumerable<long> CategoryIds { get; set; } = default!;

    [JsonPropertyName("is_content_public")]
    public bool IsContentPublic { get; set; }
}
