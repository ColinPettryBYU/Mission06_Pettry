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
    }
}
