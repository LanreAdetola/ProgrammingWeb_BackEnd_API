using Microsoft.AspNetCore.Mvc;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;

namespace NomadsNestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampingSpotController : ControllerBase
    {
        private readonly ICampingSpotRepository _campingSpotRepository;


        public CampingSpotController(ICampingSpotRepository campingSpotRepository)
        {
            _campingSpotRepository = campingSpotRepository;
        }

        // GET: api/CampingSpot
        [HttpGet]
        public IActionResult Get()
        {
            var campingSpots = _campingSpotRepository.GetAll();
            return Ok(campingSpots);
        }

        // GET: api/CampingSpot/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var campingSpot = _campingSpotRepository.GetById(id);
            if (campingSpot == null)
            {
                return NotFound();
            }
            return Ok(campingSpot);
        }

        // POST: api/CampingSpot
        [HttpPost]
        public IActionResult Post([FromBody] CampingSpot campingSpot)
        {
            _campingSpotRepository.Insert(campingSpot);
            return CreatedAtAction(nameof(Get), new { id = campingSpot.Id }, campingSpot);
        }

        // PUT: api/CampingSpot/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CampingSpot campingSpot)
        {
            if (id != campingSpot.Id)
            {
                return BadRequest();
            }

            _campingSpotRepository.Update(campingSpot);
            return NoContent();
        }

        // DELETE: api/CampingSpot/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCampingSpot = _campingSpotRepository.GetById(id);
            if (existingCampingSpot == null)
            {
                return NotFound();
            }

            _campingSpotRepository.Delete(id);
            return NoContent();
        }


        // GET: api/CampingSpot/User/5
        [HttpGet("User/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var campingSpots = _campingSpotRepository.GetByUserId(userId);
            if (campingSpots == null || !campingSpots.Any())
            {
                return NotFound();
            }
            return Ok(campingSpots);
        }
    }
}