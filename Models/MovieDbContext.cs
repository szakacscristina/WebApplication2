using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "First Movie",
                    Description = "description of the movie",
                    MovieUpKeepGenre = MovieUpKeepGenre.Horror,
                    DurationInMin = 150,
                    YearOfRelease = 1998,
                    Director = "Who Cares",
                    DateAdded = DateTime.Now,
                    Rating = 1,
                    WasWatched = false
                });
        }
    }
}