using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseProg6213Tut.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; }
        [Required]
        public int LearnerID { get; set; }
        [ForeignKey("LearnerID")]
        public User? Learner { get; set; }
        [Required]
        public int WorkshopID { get; set; }
        [ForeignKey("WorkshopID")]
        public Workshop? Workshop { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }
        [Required]
        public string RegistrationStatus { get; set; } = "Pending"; // Pending / Confirmed
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}