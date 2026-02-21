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

        // Foreign key to Category table (optional)
        public int? CategoryId { get; set; }

        // Navigation property for Category
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // Movie title - required
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; } = string.Empty;

        // Release year - required, must be 1888 or later (year the first movie was made)
        [Required(ErrorMessage = "Please enter the year.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        // Director name - optional
        public string? Director { get; set; }

        // MPAA Rating - optional
        public string? Rating { get; set; }

        // Whether the movie has been edited - required
        public bool Edited { get; set; }

        // Person the movie is lent to - optional
        public string? LentTo { get; set; }

        // Whether the movie has been copied to Plex - required
        public bool CopiedToPlex { get; set; }

        // Additional notes - optional, limited to 25 characters
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
