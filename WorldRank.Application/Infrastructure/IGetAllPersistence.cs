using WorldRank.Domain.Entities;

namespace WorldRank.Application.Infrastructure
{
    public interface IGetAllPersistence
    {
        Task<List<Player>> GetAllAsync(CancellationToken cancellationToken);
    }
}