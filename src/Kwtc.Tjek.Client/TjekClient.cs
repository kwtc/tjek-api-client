using System.Text;
using System.Text.Json;
using CommunityToolkit.Diagnostics;
using Kwtc.Tjek.Client.Abstractions;
using Kwtc.Tjek.Client.Abstractions.Models;

namespace Kwtc.Tjek.Client;

public class TjekClient : ITjekClient
{
    private readonly IHttpClientFactory httpClientFactory;

    public TjekClient(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IReadOnlyList<Offer>> SearchOffers(
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
        var queryString = BuildQueryString(new Dictionary<string, string>
        {
            { "query", $"{query}" },
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

    public async Task<IReadOnlyList<Offer>> ListOffers(string? dealerId = null, string? catalogId = null, string? publicationType = null, int? limit = null, int? offset = null, string? orderBy = null, CancellationToken cancellationToken = default)
    {
        // Build query string
        var builder = new StringBuilder();
        var queryString = BuildQueryString(new Dictionary<string, string>
        {
            { "dealer_id", $"{dealerId}" },
            { "catalog_id", $"{catalogId}" },
            { "types", $"{publicationType}" },
            { "order_by", $"{orderBy ?? "page"}" },
            { "offset", $"{offset}" },
            { "limit", $"{limit}" },
        }, builder);

        var client = this.httpClientFactory.CreateClient(Constants.HttpClientName);
        var response = await client.GetAsync($"v2/offers{queryString}", cancellationToken);

        response.EnsureSuccessStatusCode();

        var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        if (contentStream.Length == 0)
        {
            throw new HttpRequestException(HttpRequestError.InvalidResponse, "Response content is empty");
        }

        var result = await JsonSerializer.DeserializeAsync<IReadOnlyList<Offer>>(contentStream, cancellationToken: cancellationToken);

        return result ?? [];
    }

    public async Task<Offer?> GetOffer(string id, CancellationToken cancellationToken = default)
    {
        Guard.IsNotNullOrEmpty(id, nameof(id));

        var client = this.httpClientFactory.CreateClient(Constants.HttpClientName);
        var response = await client.GetAsync($"v2/offers/{id}", cancellationToken);

        response.EnsureSuccessStatusCode();

        var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        if (contentStream.Length == 0)
        {
            throw new HttpRequestException(HttpRequestError.InvalidResponse, "Response content is empty");
        }

        return await JsonSerializer.DeserializeAsync<Offer>(contentStream, cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyList<Catalog>> ListCatalogs(string? dealerId = null, string? publicationType = null, int? limit = null, int? offset = null, string? orderBy = null, CancellationToken cancellationToken = default)
    {
        // Build query string
        var builder = new StringBuilder();
        var queryString = BuildQueryString(new Dictionary<string, string>
        {
            { "dealer_id", $"{dealerId}" },
            { "types", $"{publicationType}" },
            { "order_by", $"{orderBy}" },
            { "offset", $"{offset}" },
            { "limit", $"{limit}" },
        }, builder);

        var client = this.httpClientFactory.CreateClient(Constants.HttpClientName);
        var response = await client.GetAsync($"v2/catalogs{queryString}", cancellationToken);

        response.EnsureSuccessStatusCode();

        var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        if (contentStream.Length == 0)
        {
            throw new HttpRequestException(HttpRequestError.InvalidResponse, "Response content is empty");
        }

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        
        var result = await JsonSerializer.DeserializeAsync<IReadOnlyList<Catalog>>(contentStream, cancellationToken: cancellationToken);

        return result ?? [];
    }

    public async Task<Catalog?> GetCatalog(string id, CancellationToken cancellationToken = default)
    {
        Guard.IsNotNullOrEmpty(id, nameof(id));

        var client = this.httpClientFactory.CreateClient(Constants.HttpClientName);
        var response = await client.GetAsync($"v2/catalogs/{id}", cancellationToken);

        response.EnsureSuccessStatusCode();

        var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        if (contentStream.Length == 0)
        {
            throw new HttpRequestException(HttpRequestError.InvalidResponse, "Response content is empty");
        }

        return await JsonSerializer.DeserializeAsync<Catalog>(contentStream, cancellationToken: cancellationToken);
    }

    private static string BuildQueryString(IDictionary<string, string> parameters, StringBuilder builder)
    {
        var i = 0;
        foreach (var parameter in parameters)
        {
            if (string.IsNullOrEmpty(parameter.Value))
            {
                continue;
            }

            builder.Append(i == 0 ? "?" : "&");
            builder.Append($"{parameter.Key}={parameter.Value.ToValidUri()}");

            i++;
        }

        return builder.ToString();
    }
}
