using Microsoft.AspNetCore.Mvc;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;

namespace NomadsNestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenitysController : ControllerBase
    {
        private readonly IAmenityRepository _amenityRepository;

        public AmenitysController(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }

        // GET: api/Amenity
        [HttpGet]
        public IActionResult Get()
        {
            var amenities = _amenityRepository.GetAll();
            return Ok(amenities);
        }

        // GET: api/Amenity/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var amenity = _amenityRepository.GetById(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return Ok(amenity);
        }

        // POST: api/Amenity
        [HttpPost]
        public IActionResult Post([FromBody] Amenity amenity)
        {
            _amenityRepository.Insert(amenity);
            return CreatedAtAction(nameof(Get), new { id = amenity.Id }, amenity);
        }

        // PUT: api/Amenity/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }

            _amenityRepository.Update(amenity);
            return NoContent();
        }

        // DELETE: api/Amenity/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAmenity = _amenityRepository.GetById(id);
            if (existingAmenity == null)
            {
                return NotFound();
            }

            _amenityRepository.Delete(id);
            return NoContent();
        }


    }
}
