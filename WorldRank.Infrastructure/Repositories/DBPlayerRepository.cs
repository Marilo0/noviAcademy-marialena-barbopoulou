using Microsoft.EntityFrameworkCore;
using WorldRank.Application.Interfaces;
using WorldRank.Domain.Entities;
using WorldRank.Infrastructure.Persistence;

namespace WorldRank.Infrastructure.Repositories;

public class DBPlayerRepository : IPlayerRepository
{
    private readonly WorldRankDbContext _context;

    public DBPlayerRepository(WorldRankDbContext context)
    {
        _context = context;
    }

    public void AddPlayer(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
    }

    public void DeletePlayer(int playerId)
    {
        var player = _context.Players
        .FirstOrDefault(p => p.Id == playerId);

        if (player == null)
            return;

        _context.Players.Remove(player);

        _context.SaveChanges();
    }

    public Player? FindPlayer(int playerId)
    {
        return _context.Players
        .AsNoTracking()
        .FirstOrDefault(p => p.Id == playerId);
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return _context.Players
        .AsNoTracking()
        .ToList();
    }

    public IEnumerable<IGrouping<int, Player>> GroupPlayersByScore()
    {
        return _context.Players
        .AsNoTracking()
        .ToList()
        .GroupBy(p => p.Score);
    }
}