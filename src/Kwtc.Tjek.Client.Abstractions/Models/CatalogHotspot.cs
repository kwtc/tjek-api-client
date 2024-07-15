using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class CatalogHotspot
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("locations")]
    public IDictionary<decimal, decimal[][]> Locations { get; set; } = default!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("run_from")]
    public int FromDate { get; set; } = default!;

    [JsonPropertyName("run_till")]
    public int ToDate { get; set; } = default!;

    [JsonPropertyName("heading")]
    public string Heading { get; set; } = default!;

    [JsonPropertyName("webshop")]
    public string? Webshop { get; set; }

    [JsonPropertyName("offer")]
    public CatalogHotspotOffer Offer { get; set; }

    [JsonPropertyName("id_collection")]
    public Id[] IdCollection { get; set; } = default!;
}
