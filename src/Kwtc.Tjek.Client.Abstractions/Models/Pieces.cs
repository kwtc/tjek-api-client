using System.Text.Json.Serialization;

namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Pieces
{
    [JsonPropertyName("from")]
    public long From { get; set; }

    [JsonPropertyName("to")]
    public long To { get; set; }
}
