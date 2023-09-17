using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepositories
    {
        Task<List<Region>> GetAllAsync();
    }
}
