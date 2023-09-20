using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbcontext;

        public SQLWalkRepository(NZWalksDbContext dbcontext) {
            _dbcontext = dbcontext;
        }
        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await _dbcontext.Walks.AddAsync(walk);
            await _dbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await _dbcontext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }
    }
}
