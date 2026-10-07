using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseProg6213Tut.Models
{
    public class Workshop
    {
        [Key]
        public int WorkshopID { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
        [Required, MaxLength(200)]
        public string Location { get; set; } = string.Empty;
        [Required]
        public int DurationHours { get; set; }
        [Required]
        public string WorkshopType { get; set; } = "In-Person"; 
        public string? BannerImageUrl { get; set; }

        [Required]
        public int InstructorID { get; set; }
        [ForeignKey("InstructorID")]
        public User? Instructor { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}