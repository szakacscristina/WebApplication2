using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowersApp.ViewModels.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.ViewModels;
//using WebApplication2.ViewModels.Collections;

namespace WebApplication2.Controllers
{


    // TODO: make CRUD comments work with URL api/Movies/{id}/Comments
    // TODO: make CRUD comments with another comments controller: api/comments/{movie id}
    // TODO: write a validator for comments

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public MoviesController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies, read more about swagger: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
        /// <summary>
        /// Gets a list of all the flowers. 
        /// </summary>
        /// <param name="from">Filter flowers added from this date time (inclusive). Leave empty for no lower limit.</param>
        /// <param name="to">Filter flowers add up to this date time (inclusive). Leave empty for no upper limit.</param>
        /// <param name="page">The page of results, starting from 0.</param>
        /// <param name="itemsPerPage">The number of flowers to display per page.</param>
        /// <returns>A list of Flower objects.</returns>       
        [HttpGet]
        public async Task<IActionResult> GetMovies(
            [FromQuery] DateTimeOffset? from = null,
            [FromQuery] DateTimeOffset? to = null,
            [FromQuery] int page = 0,
            [FromQuery] int itemsPerPage = 15)
        {
            var identity = User.Identity;

            IQueryable<Movie> result = _context.Movies;
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
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .Select(f => MovieWithNumberOfComments.FromMovie(f))
                .ToListAsync();

            var paginatedList = new PaginatedList<MovieWithNumberOfComments>(page, await result.CountAsync(), itemsPerPage);
            paginatedList.Items.AddRange(resultList);

            return Ok(paginatedList);
        }

        // GET: api/Movies/5
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
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
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