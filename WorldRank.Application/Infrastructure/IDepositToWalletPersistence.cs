using WorldRank.Domain.Entities;

namespace WorldRank.Application.Infrastructure
{
    public interface IDepositToWalletPersistence
    {
        public Task<Wallet?> DepositAsync(int walletId, decimal amount, CancellationToken cancellationToken);
    }
}