using System.Text;
using System.Text.Json;
using CommunityToolkit.Diagnostics;
using Kwtc.Tjek.Client.Abstractions;
using Kwtc.Tjek.Client.Abstractions.Models;

namespace Kwtc.Tjek.Client;

public class Client : IClient
{
    private readonly IHttpClientFactory httpClientFactory;

    public Client(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IReadOnlyList<Offer>> Search(
        string query,
        string? dealerId = null,
        string? catalogId = null,
        string? publicationType = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        Guard.IsNotNullOrEmpty(query, nameof(query));

        // Build query string
        var builder = new StringBuilder();
        builder.Append($"?query={query.ToValidUri()}");

        var queryString = BuildQueryString(new Dictionary<string, string>
        {
            { "dealer_id", $"{dealerId}" },
            { "catalog_id", $"{catalogId}" },
            { "types", $"{publicationType}" },
            { "limit", $"{limit}" },
        }, builder);

        var client = this.httpClientFactory.CreateClient(Constants.HttpClientName);
        var response = await client.GetAsync($"v2/offers/search{queryString}", cancellationToken);

        response.EnsureSuccessStatusCode();

        var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        if (contentStream.Length == 0)
        {
            throw new HttpRequestException(HttpRequestError.InvalidResponse, "Response content is empty");
        }

        var result = await JsonSerializer.DeserializeAsync<IReadOnlyList<Offer>>(contentStream, cancellationToken: cancellationToken);

        return result ?? [];
    }

    private static string BuildQueryString(IDictionary<string, string> parameters, StringBuilder builder)
    {
        foreach (var parameter in parameters)
        {
            if (string.IsNullOrEmpty(parameter.Value))
            {
                continue;
            }

            builder.Append($"&{parameter.Key}={parameter.Value.ToValidUri()}");
        }

        return builder.ToString();
    }
}
