using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZWalks.API.Data;
using NZWalks.API.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepositories _regionRepositories;
        public RegionsController(NZWalksDbContext context, IRegionRepositories repositories) { 
            _context = context;
            _regionRepositories = repositories;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var regions = await _regionRepositories.GetAllAsync();

            var regionsDTO = new List<RegionsDTO>();

            foreach(var region in regions) { 
         
                regionsDTO.Add(new RegionsDTO() { 
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return Ok(regionsDTO);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepositories.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = new RegionsDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] RegionRequestDTO addRegionRequestDTO)
        {

            // Map to domain model

            var Region = new Region()
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };

            Region = await _regionRepositories.CreateAsync(Region);

            var regionDTO = new RegionsDTO()
            {
                Id = Region.Id,
                Code = Region.Code,
                Name = Region.Name,
                RegionImageUrl = Region.RegionImageUrl
            };

            return CreatedAtAction(nameof(CreateRegion), new { id = regionDTO.Id }, regionDTO);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> updateRegion([FromRoute] Guid id, RegionRequestDTO editRegionRequestDTO)
        {
            var regionEntity = new Region()
            {
                Code = editRegionRequestDTO.Code,
                Name = editRegionRequestDTO.Name,
                RegionImageUrl = editRegionRequestDTO.RegionImageUrl
            };

            regionEntity = await _regionRepositories.UpdateAsync(id, regionEntity);

            if(regionEntity == null)
            {
                return NotFound();
            }

            var regionDTO = new RegionsDTO()
            {
                Id = regionEntity.Id,
                Code = regionEntity.Code,
                Name = regionEntity.Name,
                RegionImageUrl = regionEntity.RegionImageUrl
            };

            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> deleteRegion([FromRoute] Guid id)
        {
            var region = await _regionRepositories.DeleteAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }
    }
}
