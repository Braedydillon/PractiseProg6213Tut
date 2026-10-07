using System.ComponentModel.DataAnnotations;

namespace PractiseProg6213Tut.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required, MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required, MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = "Learner"; 
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }
    }
}