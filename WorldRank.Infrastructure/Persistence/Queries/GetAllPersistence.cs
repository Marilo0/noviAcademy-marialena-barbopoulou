using Microsoft.EntityFrameworkCore;
using WorldRank.Application.Infrastructure;
using WorldRank.Domain.Entities;
using WorldRank.Infrastructure.Data;

namespace WorldRank.Infrastructure.Persistence.Queries
{
    public class GetAllPersistence : IGetAllPersistence
    {
        private readonly WorldRankDbContext _dbContext;

        public GetAllPersistence(WorldRankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Player>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Players.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}