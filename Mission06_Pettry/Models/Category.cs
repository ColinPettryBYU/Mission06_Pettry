// Category model - represents a movie genre/category for normalization
using System.ComponentModel.DataAnnotations;

namespace Mission06_Pettry.Models
{
    public class Category
    {
        // Primary key
        [Key]
        public int CategoryId { get; set; }

        // Category name (e.g., Action/Adventure, Comedy, Drama, etc.)
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}
