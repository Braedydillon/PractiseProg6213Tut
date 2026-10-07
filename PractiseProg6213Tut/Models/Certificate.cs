using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseProg6213Tut.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateID { get; set; }
        [Required]
        public int RegistrationID { get; set; }
        [ForeignKey("RegistrationID")]
        public Registration? Registration { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        [Required, MaxLength(10)]
        public string FinalGrade { get; set; } = string.Empty;
        public string? CertificateUrl { get; set; }
    }
}