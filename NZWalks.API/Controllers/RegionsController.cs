using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZWalks.API.CustomActionFilters;
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
        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext context, IRegionRepositories repositories, IMapper mapper) { 
            _context = context;
            _regionRepositories = repositories;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var regions = await _regionRepositories.GetAllAsync();

            var regionsDTO = _mapper.Map<List<RegionsDTO>>(regions);

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

            var regionDTO =  _mapper.Map<RegionsDTO>(region);

            return Ok(regionDTO);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRegion([FromBody] RegionRequestDTO addRegionRequestDTO)
        {
                // Map to domain model
                var Region = _mapper.Map<Region>(addRegionRequestDTO);

                Region = await _regionRepositories.CreateAsync(Region);

                var regionDTO = _mapper.Map<RegionsDTO>(Region);

                return CreatedAtAction(nameof(CreateRegion), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> updateRegion([FromRoute] Guid id, RegionRequestDTO editRegionRequestDTO)
        {
            if (ModelState.IsValid)
            {
                var regionEntity = _mapper.Map<Region>(editRegionRequestDTO);

                regionEntity = await _regionRepositories.UpdateAsync(id, regionEntity);

                if (regionEntity == null)
                {
                    return NotFound();
                }

                var regionDTO = _mapper.Map<RegionsDTO>(regionEntity);

                return Ok(regionDTO);
            }
            else
            {
                return BadRequest(ModelState);
            }
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
