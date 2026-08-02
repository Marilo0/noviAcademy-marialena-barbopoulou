using Microsoft.EntityFrameworkCore;
using WorldRank.Application.Infrastructure;
using WorldRank.Domain.Entities;
using WorldRank.Infrastructure.Data;

namespace WorldRank.Infrastructure.Persistence.Queries;

public class GetPlayerByIdPersistence : IGetPlayerByIdPersistence
{
    private readonly WorldRankDbContext _dbContext;
    public GetPlayerByIdPersistence(WorldRankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Player?> GetByIdAsync(int playerId, CancellationToken cancellationToken)
    {
        return await _dbContext.Players.AsNoTracking().FirstOrDefaultAsync(player => player.Id == playerId, cancellationToken);
    }
}