using WorldRank.Domain.Entities;

namespace WorldRank.Application.Infrastructure
{
    public interface IGetPlayerByIdPersistence
    {
        Task<Player?> GetByIdAsync(int playerId, CancellationToken cancellationToken);
    }
}