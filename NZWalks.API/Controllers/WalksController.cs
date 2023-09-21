using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _repository;
        public WalksController(IMapper mapper, IWalkRepository repository) { 
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] WalksRequestDTO walksRequestDTO)
        {
            if (ModelState.IsValid)
            {
                var walkEntity = _mapper.Map<Walk>(walksRequestDTO);

                await _repository.CreateWalkAsync(walkEntity);

                return Ok(_mapper.Map<WalksDTO>(walkEntity));
            } 
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            var walks = await _repository.GetAllWalksAsync(filterOn, filterQuery, sortBy, isAscending ?? true);
            if(walks == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<List<WalksDTO>>(walks));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await _repository.GetWalkAsync(id);

            if(walk == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalksDTO>(walk));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] WalksRequestDTO walkRequestDTO)
        {
            if (ModelState.IsValid)
            {
                var walk = _mapper.Map<Walk>(walkRequestDTO);

                walk = await _repository.UpdateWalkAsync(id, walk);

                if (walk == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<WalksDTO>(walk));
            } 
            else
            {
                return BadRequest(ModelState);
            }


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var walk = await _repository.DeleteWalkAsync(id);

            if(walk == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalksDTO>(walk));
        }
    }
}
