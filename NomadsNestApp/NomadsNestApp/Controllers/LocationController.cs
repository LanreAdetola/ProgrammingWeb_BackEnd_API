using Microsoft.AspNetCore.Mvc;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;

namespace NomadsNestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET: api/Location
        [HttpGet]
        public IActionResult Get()
        {
            var locations = _locationRepository.GetAll();
            return Ok(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var location = _locationRepository.GetById(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // POST: api/Location
        [HttpPost]
        public IActionResult Post([FromBody] Location location)
        {
            _locationRepository.Insert(location);
            return CreatedAtAction(nameof(Get), new { id = location.Id }, location);
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _locationRepository.Update(location);
            return NoContent();
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingLocation = _locationRepository.GetById(id);
            if (existingLocation == null)
            {
                return NotFound();
            }

            _locationRepository.Delete(id);
            return NoContent();
        }
    }
}
