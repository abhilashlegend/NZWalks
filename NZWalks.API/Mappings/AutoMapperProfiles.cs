using AutoMapper;
using NZWalks.API.DTO;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() { 
            CreateMap<Region, RegionsDTO>().ReverseMap();
            CreateMap<RegionRequestDTO, Region>().ReverseMap();

            CreateMap<Walk, WalksDTO>().ReverseMap();
            CreateMap<Walk, WalksRequestDTO>().ReverseMap();


        }
    }
}
