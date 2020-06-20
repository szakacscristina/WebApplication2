using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApplication2.Helpers;

namespace WebApplication2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesDbContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesDbContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB table has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        Description = "sirop",
                        MovieUpKeepGenre = MovieUpKeepGenre.Comedy,
                        DurationInMin = 100,
                        YearOfRelease = 2019 - 10 - 03,
                        Director = "Ion",
                        DateAdded = DateTime.Parse("1990-12-5"),
                        Rating = 2,
                        WasWatched = true
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        Description = "pistolari",
                        MovieUpKeepGenre = MovieUpKeepGenre.Action,
                        DurationInMin = 150,
                        YearOfRelease = 2019 - 11 - 03,
                        Director = "Gheorghe",
                        DateAdded = DateTime.Parse("2000-10-10"),
                        Rating = 1,
                        WasWatched = false
                    }

                    );
                context.SaveChanges();
            }


        }
    }

}