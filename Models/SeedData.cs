
using WebApplication2.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesDbContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesDbContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Count() >= 2000)
                {
                    return;   // DB table has been seeded
                }

                for (int i = 1; i <= 2000; ++i)
                {
                    context.Movies.Add(
                        new Movie
                        {
                            Title = $"Rio Bravo-{i}",
                            Description = $"pistolari-{i}",
                            MovieUpKeepGenre = MovieUpKeepGenre.Action,
                            DurationInMin = 150,
                            YearOfRelease = 2019 - 11 - 03,
                            Director = "Gheorghe",
                            DateAdded = DateTime.Parse("2000-10-10"),
                            Rating = 1,
                            WasWatched = true
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}