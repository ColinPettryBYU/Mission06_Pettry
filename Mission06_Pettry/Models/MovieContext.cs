// MovieContext - Entity Framework Core DbContext for the movie collection database
using Microsoft.EntityFrameworkCore;

namespace Mission06_Pettry.Models
{
    public class MovieContext : DbContext
    {
        // Constructor accepting options for dependency injection
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // DbSet for Movies table
        public DbSet<Movie> Movies { get; set; }

        // DbSet for Categories table
        public DbSet<Category> Categories { get; set; }

        // Seed data for categories and initial movies
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Category data (genres from Joel's collection)
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            // Seed 3 favorite movies into the database
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 1, // Action/Adventure
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Year = 2001,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = null,
                    Notes = null
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryId = 2, // Comedy
                    Title = "The Princess Bride",
                    Year = 1987,
                    Director = "Rob Reiner",
                    Rating = "PG",
                    Edited = false,
                    LentTo = null,
                    Notes = null
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryId = 3, // Drama
                    Title = "The Shawshank Redemption",
                    Year = 1994,
                    Director = "Frank Darabont",
                    Rating = "R",
                    Edited = true,
                    LentTo = null,
                    Notes = "Classic film"
                }
            );
        }
    }
}
