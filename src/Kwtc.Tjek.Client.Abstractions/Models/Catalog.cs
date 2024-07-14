using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Catalog
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;
    
    [JsonPropertyName("ern")]
    public string Ern { get; set; } = default!;

    [JsonPropertyName("run_from")]
    public string FromDate { get; set; } = default!;

    [JsonPropertyName("store_id")]
    public string? StoreId { get; set; }

    [JsonPropertyName("store_url")]
    public string StoreUrl { get; set; } = default!;

    [JsonPropertyName("images")]
    public Images Images { get; set; } = default!;
    
    [JsonPropertyName("types")]
    public string[] Types { get; set; } = default!;

    [JsonPropertyName("incito_publication_id")]
    public string? IncitoPublicationId { get; set; }
    
    [JsonPropertyName("all_stores")]
    public bool AllStores { get; set; }
    
    [JsonPropertyName("dealer_url")]
    public string DealerUrl { get; set; } = default!;
    
    [JsonPropertyName("branding")]
    public Branding Branding { get; set; } = default!;
    
    [JsonPropertyName("pdf_url")]
    public string PdfUrl { get; set; } = default!;
    
    [JsonPropertyName("label")]
    public string Label { get; set; } = default!;
    
    [JsonPropertyName("run_till")]
    public string ToDate { get; set; } = default!;

    [JsonPropertyName("background")]
    public string Background { get; set; } = default!;

    [JsonPropertyName("category_ids")]
    public string[] CategoryIds { get; set; } = default!;

    [JsonPropertyName("offer_count")]
    public long OfferCount { get; set; }

    [JsonPropertyName("page_count")]
    public long PageCount { get; set; }

    [JsonPropertyName("dealer_id")]
    public string DealerId { get; set; } = default!;
    
    [JsonPropertyName("dealer")]
    public Dealer Dealer { get; set; } = default!;
    
    [JsonPropertyName("dimensions")]
    public Dimensions Dimensions { get; set; } = default!;
}
