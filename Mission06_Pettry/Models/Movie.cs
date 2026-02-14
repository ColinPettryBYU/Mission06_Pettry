// Movie model - represents a movie in Joel Hilton's film collection
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Pettry.Models
{
    public class Movie
    {
        // Primary key
        [Key]
        public int MovieId { get; set; }

        // Foreign key to Category table (normalization)
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        // Navigation property for Category
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // Movie title - required
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; } = string.Empty;

        // Release year - required
        [Required(ErrorMessage = "Please enter the year.")]
        public int Year { get; set; }

        // Director name - required
        [Required(ErrorMessage = "Please enter a director.")]
        public string Director { get; set; } = string.Empty;

        // MPAA Rating (G, PG, PG-13, R) - required, uses dropdown
        [Required(ErrorMessage = "Please select a rating.")]
        public string Rating { get; set; } = string.Empty;

        // Whether the movie has been edited - optional boolean
        public bool Edited { get; set; }

        // Person the movie is lent to - optional
        public string? LentTo { get; set; }

        // Additional notes - optional, limited to 25 characters
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
