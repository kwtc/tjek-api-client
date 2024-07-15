using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class CatalogHotspotOffer
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("ern")]
    public string Ern { get; set; } = default!;

    [JsonPropertyName("heading")]
    public string Heading { get; set; } = default!;

    [JsonPropertyName("pricing")]
    public Pricing Pricing { get; set; } = default!;

    [JsonPropertyName("quantity")]
    public Quantity Quantity { get; set; } = default!;

    [JsonPropertyName("run_from")]
    public string FromDate { get; set; } = default!;

    [JsonPropertyName("run_till")]
    public string ToDate { get; set; } = default!;

    [JsonPropertyName("publish")]
    public string Publish { get; set; } = default!;
}
