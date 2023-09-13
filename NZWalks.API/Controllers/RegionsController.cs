﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
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

            return Ok(regions);
        }
    }
}
