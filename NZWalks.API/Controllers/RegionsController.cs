using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
           var regions = _context.Regions.ToList();

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
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _context.Regions.FirstOrDefault(region => region.Id == id);

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
    }
}
