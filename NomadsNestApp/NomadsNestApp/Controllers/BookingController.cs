using Microsoft.AspNetCore.Mvc;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;

namespace NomadsNestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        // GET: api/Booking
        [HttpGet]
        public IActionResult Get()
        {
            var bookings = _bookingRepository.GetAll();
            return Ok(bookings);
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var booking = _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        // POST: api/Booking
        [HttpPost]
        public IActionResult Post([FromBody] Booking booking)
        {
            if (booking == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState); // Handle validation errors
            }

            _bookingRepository.Insert(booking);
            return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            _bookingRepository.Update(booking);
            return NoContent();
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingBooking = _bookingRepository.GetById(id);
            if (existingBooking == null)
            {
                return NotFound();
            }

            _bookingRepository.Delete(id);
            return NoContent();
        }


    }
}
