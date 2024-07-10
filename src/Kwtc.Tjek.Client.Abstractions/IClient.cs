using Kwtc.Tjek.Client.Abstractions.Models;

namespace Kwtc.Tjek.Client.Abstractions;

public interface IClient
{
    public Task<IReadOnlyList<Offer>> Search(
        string query,
        string? dealerId = null,
        string? catalogId = null,
        string? publicationType = null,
        int? limit = null,
        CancellationToken cancellationToken = default);
}
