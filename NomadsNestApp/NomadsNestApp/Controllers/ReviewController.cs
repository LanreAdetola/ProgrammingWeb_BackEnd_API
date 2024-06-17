using Microsoft.AspNetCore.Mvc;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;

namespace NomadsNestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/Review
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _reviewRepository.GetAll();
            return Ok(reviews);
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _reviewRepository.GetById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST: api/Review
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            _reviewRepository.Insert(review);
            return CreatedAtAction(nameof(Get), new { id = review.Id }, review);
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            _reviewRepository.Update(review);
            return NoContent();
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingReview = _reviewRepository.GetById(id);
            if (existingReview == null)
            {
                return NotFound();
            }

            _reviewRepository.Delete(id);
            return NoContent();
        }
    }
}
