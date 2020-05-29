using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{

    public enum MovieUpKeepGenre
    {
        Action,
        Comedy,
        Horror,
        Thriller
    }
    public class Movie
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

        public List<Comment> Comments { get; set; }

      

    }
}
