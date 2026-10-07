using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; 

namespace PractiseProg6213Tut.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int WorkshopID { get; set; }

        [ForeignKey("WorkshopID")]
        [JsonIgnore] // This stops the cycle by ignoring the parent workshop during serialization
        public Workshop? Workshop { get; set; }
    }
}