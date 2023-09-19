using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions options):base(options) { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("2638289f-5e00-4a48-8b6b-bb6aae5db7c3"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("9cda2b73-d689-4e15-8e1a-782327899929"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("41c304a8-b65b-404f-8691-811ff1892495"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("7bfa23c7-df03-467c-b30b-b1e4b6e68d7d"),
                    Name = "KARNATAKA",
                    Code = "KA",
                    RegionImageUrl = "images/karnataka.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("b202bec4-5586-460d-b33a-7546a8506eef"),
                    Name = "ANDRA PRADESH",
                    Code = "AP",
                    RegionImageUrl = "images/andra.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("dbd0bbf0-0565-42b2-ab6b-d6fc46d5bb5c"),
                    Name = "TAMIL NADU",
                    Code = "TN",
                    RegionImageUrl = "images/tamilnadu.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("fd45ffca-996b-47d1-9635-b7747303c0d8"),
                    Name = "KERALA",
                    Code = "KE",
                    RegionImageUrl = "images/kerala.jpeg"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
