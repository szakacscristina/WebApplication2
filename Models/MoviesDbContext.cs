using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class MoviesDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
        { }
    }
}