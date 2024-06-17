using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Helpers;
using NomadsNestApp.Models;
using NomadsNestApp.Models.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Threading.Tasks;

namespace NomadsNestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly PasswordHelper _passwordHelper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserController(IUserRepository userRepository, IConfiguration configuration, PasswordHelper passwordHelper, IWebHostEnvironment hostingEnvironment)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _passwordHelper = passwordHelper;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null || string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password))
            {
                return BadRequest(new { message = "Email and password are required" });
            }

            var existingUser = _userRepository.GetByEmail(registerDto.Email);
            if (existingUser != null)
            {
                return Conflict("Email address already exists");
            }

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = _passwordHelper.HashPassword(registerDto.Password),
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber,
                Bookings = new List<Booking>(),
                Reviews = new List<Review>(),
            };

            _userRepository.Insert(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userRepository.Update(user);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("emails-passwords")]
        public IActionResult GetAllEmailsAndPasswords()
        {
            var users = _userRepository.GetAll()
                                       .Select(user => new {
                                           user.Id,
                                           user.Username,
                                           user.Email,
                                           user.PasswordHash,
                                           user.FirstName,
                                           user.LastName,
                                           user.PhoneNumber,
                                           user.ProfilePicturePath
                                       })
                                       .ToList();

            return Ok(users);
        }

        // endpoint to handle profile picture upload
        [HttpPost("{id}/upload-profile-picture")]
        public async Task<IActionResult> UploadProfilePicture(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Invalid file." });
            }

            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }



            if (!string.IsNullOrEmpty(user.ProfilePicturePath))
            {
                var existingImagePath = Path.Combine(_hostingEnvironment.WebRootPath, user.ProfilePicturePath);
                if (System.IO.File.Exists(existingImagePath))
                {
                    System.IO.File.Delete(existingImagePath);
                }
            }


            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "User_images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Create a unique file name
            var uniqueFileName = $"{user.Id}_{Path.GetRandomFileName()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save the file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Update the user's profile picture path
            user.ProfilePicturePath = $"User_images/{uniqueFileName}";
            _userRepository.Update(user);

            return Ok(new { path = user.ProfilePicturePath });
        }
    }
}
