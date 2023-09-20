﻿namespace NZWalks.API.DTO
{
    public class WalksDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }

        public RegionsDTO Region { get; set; }

        public DifficultyDTO Difficulty { get; set; }
    }
}
