using Microsoft.EntityFrameworkCore;
using WorldRank.Application.Interfaces;
using WorldRank.Domain.Entities;
using WorldRank.Infrastructure.Persistence;

namespace WorldRank.Infrastructure.Repositories;

public class DBPlayerRepository : IPlayerRepository
{
    private readonly WorldRankDbContext _db;

    public DBPlayerRepository(WorldRankDbContext db) => _db = db;

    public async Task AddAsync(Player player, CancellationToken cancellationToken = default)
    {
        await _db.Players.AddAsync(player, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task<Player?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        _db.Players.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public Task<Player?> GetByNameAsync(string name, CancellationToken cancellationToken = default) =>
        _db.Players.AsNoTracking().FirstOrDefaultAsync(p => p.Name == name, cancellationToken);

    public async Task<IReadOnlyList<Player>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _db.Players.AsNoTracking().ToListAsync(cancellationToken);

    public async Task DeletePlayerAsync(int playerId, CancellationToken cancellationToken)
    {
        var player = await _db.Players.Where(item => item.Id == playerId).FirstOrDefaultAsync(cancellationToken);

        if (player is null)
        {
            return;
        }
        _db.Players.Remove(player);
        await _db.SaveChangesAsync(cancellationToken);

    }

    public async Task<List<IGrouping<int, Player>>> GroupPlayersByScoreAsync(CancellationToken cancellationToken)
    {
        var players = await _db.Players.AsNoTracking().ToListAsync(cancellationToken);

        return players.GroupBy(player => player.Score).OrderByDescending(group => group.Key).ToList();
    }
}
