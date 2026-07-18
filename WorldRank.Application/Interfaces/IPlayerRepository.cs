using WorldRank.Domain.Entities;

namespace WorldRank.Application.Interfaces;

public interface IPlayerRepository
{
    Task AddAsync(Player player, CancellationToken cancellationToken = default);
    Task<Player?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Player?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Player>> GetAllAsync(CancellationToken cancellationToken = default);
    Task DeletePlayerAsync(int playerId, CancellationToken cancellationToken = default);
    Task<List<IGrouping<int, Player>>> GroupPlayersByScoreAsync(CancellationToken cancellationToken = default);
}
