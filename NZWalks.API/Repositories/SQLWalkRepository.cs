﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Walk?> GetWalkAsync(Guid id)
        {
            var walk = await _dbcontext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);

            if(walk == null)
            {
                return null;
            }

            return walk;
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var walkEntity = await _dbcontext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(walkEntity == null)
            {
                return null;
            }

            walkEntity.Difficulty = walk.Difficulty;
            walkEntity.DifficultyId = walk.DifficultyId;
            walkEntity.WalkImageUrl = walk.WalkImageUrl;
            walkEntity.LengthInKm = walk.LengthInKm;
            walkEntity.Description = walk.Description;
            walkEntity.Name = walk.Name;
            walkEntity.Region = walk.Region;
            walkEntity.RegionId = walk.RegionId;

            await _dbcontext.SaveChangesAsync();
            return walkEntity;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var existingWalk = await _dbcontext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWalk == null)
            {
                return null;
            }

            _dbcontext.Walks.Remove(existingWalk);
            await _dbcontext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
