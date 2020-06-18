using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.ViewModels;



namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public MoviesController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        /// <summary>
        /// Gets a list of all the movies
        /// </summary>
        /// <param name="from">Filter movies added from this date time (inclusive). Leave empty for no lower limit.</param>
        /// <param name="to">Filter movies added up to this date time (inclusive). Leave empty for no upper limit. </param>
        /// <returns>A list of flower objects.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieWithNumberOfComments>>> GetMovies(
            [FromQuery]DateTimeOffset? from = null,
            [FromQuery]DateTimeOffset? to = null)
        {
            IQueryable<Movie> result = _context.Movies.Include(f => f.Comments);
            if (from != null)
            {
                result = result.Where(f => from <= f.DateAdded);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }

            var resultList = await result
                .OrderByDescending(f => f.YearOfRelease)
                .Include(f => f.Comments)
                .Select(f => MovieWithNumberOfComments.FromMovie(f))
                .ToListAsync();
            return resultList;
        }


        // GET: api/Movies/5
        /// <summary>
        /// Gets a list of all movies
        /// </summary>
        /// <param name="id">Gets a movie depanding on the id. </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDetails>> GetMovie(long id)
        {
            var movie = await _context
                .Movies
                .Include(f => f.Comments)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return MovieDetails.FromMovie(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Updates a movie.
        /// </summary>
        /// <param name="id"> Updates a selected movie depending on the id.</param>
        /// <param name="movie"> Updates a selected movie depending on the name.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(long id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Adds a new movie. 
        /// </summary>
        /// <param name="movie"> Adds a new movie.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        /// <summary>
        /// Removes a movie.
        /// </summary>
        /// <param name="id">Removes a movie depending on the id.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
