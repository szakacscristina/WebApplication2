using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesDbContext(serviceProvider.GetRequiredService< DbContextOptions<MoviesDbContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                       Title = "Titanic",
                       Description = "hbwdwbbsad",
                       MovieUpKeepGenre = MovieUpKeepGenre.Horror,
                       DurationInMin = 40,
                       YearOfRelease = 2006,
                       Director = "hefue",
                       DateAdded = DateTime.Now,
                       Rating = 10,
                       WasWatched = true
                    },

                    new Movie
                    {
                        Title = "Genoveva",
                        Description = "duhfdiu",
                        MovieUpKeepGenre = MovieUpKeepGenre.Action,
                        DurationInMin = 70,
                        YearOfRelease = 2018,
                        Director = "GHF",
                        DateAdded = DateTime.Now,
                        Rating = 7,
                        WasWatched = false
                    },

                      new Movie
                      {
                          Title = "Povestea mea",
                          Description = "dwuhwaiufefie",
                          MovieUpKeepGenre = MovieUpKeepGenre.Comedy,
                          DurationInMin = 60,
                          YearOfRelease = 2020,
                          Director = "hfvf",
                          DateAdded = DateTime.Now,
                          Rating = 8,
                          WasWatched = true
                      },

                   new Movie
                   {
                       Title = "Love Affair",
                       Description = "uhsaifug",
                       MovieUpKeepGenre = MovieUpKeepGenre.Thriller,
                       DurationInMin = 150,
                       YearOfRelease = 2020,
                       Director = "HYTF",
                       DateAdded = DateTime.UtcNow,
                       Rating = 5,
                       WasWatched = false
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
