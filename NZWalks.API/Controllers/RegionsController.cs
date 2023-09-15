using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DTO;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        public RegionsController(NZWalksDbContext context) { 
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var regions = await _context.Regions.ToListAsync();

            var regionsDTO = new List<RegionsDTO>();

            foreach(var region in regions)
            {
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
            var region = await _context.Regions.FirstOrDefaultAsync(region => region.Id == id);

            if(region == null)
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

                   _context.Regions.Add(Region);
            await _context.SaveChangesAsync();

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
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return NotFound();
            }

            region.Name = editRegionRequestDTO.Name;
            region.Code = editRegionRequestDTO.Code;
            region.RegionImageUrl = editRegionRequestDTO.RegionImageUrl;

            await _context.SaveChangesAsync();


            var regionDTO = new RegionsDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> deleteRegion([FromRoute] Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();

            return Ok(region);
        }
    }
}
