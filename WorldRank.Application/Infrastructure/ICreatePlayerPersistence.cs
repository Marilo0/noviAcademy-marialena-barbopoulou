using WorldRank.Domain.Entities;

namespace WorldRank.Application.Infrastructure
{
    public interface ICreatePlayerPersistence
    {
        public Task Persist(Player player, CancellationToken cancellationToken);
    }
}