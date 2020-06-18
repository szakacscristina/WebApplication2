using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class MovieDetails
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MovieUpKeepGenre MovieUpKeepGenre { get; set; }
        public int DurationInMin { get; set; }
        public int YearOfRelease { get; set; }
        public string Director { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public int Rating { get; set; }
        public bool WasWatched { get; set; }

        public List <CommentForMovieDetails> Comments { get; set; }

        public static MovieDetails FromMovie(Movie movie)
        {
            return new MovieDetails

        {
            Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                DurationInMin = movie.DurationInMin,
                YearOfRelease = movie.YearOfRelease,
                Director = movie.Director,
                DateAdded = movie.DateAdded,
                Rating = movie.Rating,
                WasWatched = movie.WasWatched,
                Comments = movie.Comments.Select(c => CommentForMovieDetails.FromComment(c)).ToList()
            };
        }
    }
}
