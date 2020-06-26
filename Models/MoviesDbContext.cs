using WebApplication2.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class MoviesDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<MovieUserWatched> MovieUserWatched { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieUserWatched>()
                .HasIndex(f => new { f.MovieId, f.UserId })
                .IsUnique(true);
        }
    }
}