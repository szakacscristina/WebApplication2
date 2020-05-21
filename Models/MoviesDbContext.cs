using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}