using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Offer
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;
    
    [JsonPropertyName("branding")]
    public Branding Branding { get; set; } = default!;

    [JsonPropertyName("heading")]
    public string Heading { get; set; } = default!;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = default!;

    [JsonPropertyName("catalog_page")]
    public int? CatalogPage { get; set; }

    [JsonPropertyName("catalog_id")]
    public string? CatalogId { get; set; }

    [JsonPropertyName("dealer_id")]
    public string DealerId { get; set; } = default!;

    [JsonPropertyName("dealer")]
    public Dealer Dealer { get; set; } = default!;

    [JsonPropertyName("images")]
    public Images Images { get; set; } = default!;

    [JsonPropertyName("links")]
    public Links Links { get; set; } = default!;

    [JsonPropertyName("pricing")]
    public Pricing Pricing { get; set; } = default!;

    [JsonPropertyName("publish")]
    public string Publish { get; set; } = default!;

    [JsonPropertyName("run_from")]
    public string FromDate { get; set; } = default!;

    [JsonPropertyName("run_till")]
    public string ToDate { get; set; } = default!;

    [JsonPropertyName("quantity")]
    public Quantity Quantity { get; set; } = default!;
}
