using Kwtc.Tjek.Client.Abstractions.Models;

namespace Kwtc.Tjek.Client.Abstractions;

public interface ITjekClient
{
    /// <summary>
    /// Search for offers
    /// </summary>
    public Task<IReadOnlyList<Offer>> SearchOffers(
        string query,
        string? dealerId = null,
        string? catalogId = null,
        string? publicationType = null,
        int? limit = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get list of current offers
    /// </summary>
    public Task<IReadOnlyList<Offer>> ListOffers(
        string? dealerId = null,
        string? catalogId = null,
        string? publicationType = null,
        int? limit = null,
        int? offset = null,
        string? orderBy = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get offer by id
    /// </summary>
    public Task<Offer?> GetOffer(string offerId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get list of catalogs
    /// </summary>
    public Task<IReadOnlyList<Catalog>> ListCatalogs(
        string? dealerId = null,
        string? publicationType = null,
        int? limit = null,
        int? offset = null,
        string? orderBy = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get catalog by id
    /// </summary>
    public Task<Catalog?> GetCatalog(string catalogId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get catalog pages by catalog id
    /// </summary>
    public Task<IReadOnlyList<CatalogPage>> GetCatalogPages(string catalogId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get catalog page decorations by catalog id
    /// </summary>
    public Task<IReadOnlyList<CatalogPageDecoration>> GetCatalogPageDecorations(string catalogId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get catalog hotspots by catalog id
    /// </summary>
    public Task<IReadOnlyList<CatalogHotspot>> GetCatalogHotspots(string catalogId, CancellationToken cancellationToken = default);
}
