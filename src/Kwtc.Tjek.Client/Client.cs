﻿using System.Text.Json;
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

    public async Task<IReadOnlyList<Offer>> Search(string query, CancellationToken cancellationToken = default)
    {
        //https://squid-api.tjek.com/v2/offers/search?query=<term>

        // TODO: Ensure we can handle queries with whitespaces

        var client = this.httpClientFactory.CreateClient(Constants.HttpClientName);
        var response = await client.GetAsync($"v2/offers/search?query={query}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<IReadOnlyList<Offer>>(contentStream, cancellationToken: cancellationToken);

        return result ?? [];
    }
}
