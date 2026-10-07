using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PractiseProg6213Tut.Data;
using PractiseProg6213Tut.Models;

namespace PractiseProg6213Tut.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SkillForgeDbContext _context;

        public AuthController(SkillForgeDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return BadRequest(new { message = "Email is already registered." });
            }

            user.UserID = 0; // Ensure ID is auto-generated
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || user.PasswordHash != loginDto.Password)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            // Save role and user details into Session state
            HttpContext.Session.SetString("Role", user.Role);
            HttpContext.Session.SetInt32("UserID", user.UserID);
            HttpContext.Session.SetString("Username", user.Username);

            return Ok(new { message = "Login successful", role = user.Role, username = user.Username });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok(new { message = "Logged out successfully." });
        }
    }

    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}