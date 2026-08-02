using WorldRank.Domain.Entities;

namespace WorldRank.Application.Infrastructure
{
    public interface IGetWalletByIdPersistence
    {
        Task<Wallet?> GetByIdAsync(int walletId, CancellationToken cancellationToken);
    }
}