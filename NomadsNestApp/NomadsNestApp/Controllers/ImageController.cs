using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NomadsNestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly string _imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads");

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;

            // Ensure the upload directory exists
            if (!Directory.Exists(_imageDirectory))
            {
                Directory.CreateDirectory(_imageDirectory);
            }
        }

        // GET: api/Image
        [HttpGet]
        public IActionResult Get()
        {
            var images = _imageRepository.GetAll();
            return Ok(images);
        }

        // GET: api/Image/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var image = _imageRepository.GetById(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        // POST: api/Image
        [HttpPost]
        public IActionResult Post([FromForm] IFormFile file, [FromForm] int campingSpotId, [FromForm] string description, [FromForm] int uploadedBy)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Generate a unique filename
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(_imageDirectory, fileName);

            // Save the file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Create and save the image record
            var image = new Image
            {
                CampingSpotId = campingSpotId,
                UploadedBy = uploadedBy,
                UploadedAt = DateTime.UtcNow,
                Url = $"/uploads/{fileName}",
                FilePath = filePath
            };

            _imageRepository.Insert(image);
            return CreatedAtAction(nameof(Get), new { id = image.Id }, image);
        }

        // PUT: api/Image/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Image image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }

            _imageRepository.Update(image);
            return NoContent();
        }

        // DELETE: api/Image/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingImage = _imageRepository.GetById(id);
            if (existingImage == null)
            {
                return NotFound();
            }

            // Delete the file from the server
            if (System.IO.File.Exists(existingImage.FilePath))
            {
                System.IO.File.Delete(existingImage.FilePath);
            }

            _imageRepository.Delete(id);
            return NoContent();
        }
    }
}
