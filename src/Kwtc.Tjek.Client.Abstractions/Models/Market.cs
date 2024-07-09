using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Market
{
    [JsonPropertyName("slug")]
    public string Slug { get; set; } = default!;

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; } = default!;
}
