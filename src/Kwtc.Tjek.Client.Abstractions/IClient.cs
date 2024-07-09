using Kwtc.Tjek.Client.Abstractions.Models;

namespace Kwtc.Tjek.Client.Abstractions;

public interface IClient
{
    Task<IReadOnlyList<Offer>> Search(string query, CancellationToken cancellationToken = default);
}
