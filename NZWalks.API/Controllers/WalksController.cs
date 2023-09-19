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
            var walkEntity = _mapper.Map<Walk>(walksRequestDTO);

            await _repository.CreateWalkAsync(walkEntity);

            return Ok(_mapper.Map<WalksDTO>(walkEntity));
        }
    }
}
