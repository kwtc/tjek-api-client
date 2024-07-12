using Kwtc.Tjek.Client.Abstractions.Models;

namespace Kwtc.Tjek.Client.Abstractions;

public interface ITjekClient
{
    /// <summary>
    /// Search for offers
    /// </summary>
    public Task<IReadOnlyList<Offer>> Search(
        string query,
        string? dealerId = null,
        string? catalogId = null,
        string? publicationType = null,
        int? limit = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// NOT IMPLEMENTED
    /// 
    /// Get list current offers
    /// </summary>
    public Task<IReadOnlyList<Offer>> List(
        string? dealerId = null,
        string? catalogId = null,
        string? publicationType = null,
        int? limit = null,
        int? offset = null,
        string? orderBy = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// NOT IMPLEMENTED
    /// 
    /// Get offer by id
    /// </summary>
    public Task<Offer?> Offer(string id, CancellationToken cancellationToken = default);
}
