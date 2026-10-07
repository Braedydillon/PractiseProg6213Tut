using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseProg6213Tut.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        [Required]
        public int WorkshopID { get; set; }
        [ForeignKey("WorkshopID")]
        public Workshop? Workshop { get; set; }
        [Required]
        public int LearnerID { get; set; }
        [ForeignKey("LearnerID")]
        public User? Learner { get; set; }
        [Required]
        public int Rating { get; set; } // 1 to 5
        public string? Comments { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    }
}