using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Pricing
{
    [JsonPropertyName("pre_price")]
    public decimal? PrePrice { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;
}
