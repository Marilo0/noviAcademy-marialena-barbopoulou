using WorldRank.Domain.Entities;

namespace WorldRank.Application.Infrastructure
{
    public interface ICreateWalletPersistence
    {
        public Task Persist(Wallet wallet, CancellationToken cancellationToken);
    }
}