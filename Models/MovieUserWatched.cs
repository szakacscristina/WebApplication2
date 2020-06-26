using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class MovieUserWatched
    {
        public long Id { get; set; }
        // eventual un date time
        public int NumberOfWatches { get; set; }

        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}