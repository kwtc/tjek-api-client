using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Country
{
    [JsonPropertyName("id")]
    public string Code { get; set; } = default!;
}
