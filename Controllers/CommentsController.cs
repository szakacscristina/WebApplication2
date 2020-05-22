using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public CommentsController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        /// <summary>
        /// Gets a list of all the comments
        /// </summary>
        /// /// <remark>
        /// Sample request:
        /// 
        ///   GET  /api/Comments
        /// 
        /// </remark>
        ///    /// <returns> A list of Comment objects.</returns>
        /// <response code="201">Returns the list of comments.</response>
        /// <response code="400">If the list of comments is null</response>  
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
            
        }

        // GET: api/Comments/5
        /// <summary>
        /// Get a Comment with an unique id
        /// </summary>
        /// <remark>
        /// Sample request:
        /// 
        ///   GET  /api/Comments/8
        /// 
        /// </remark>
        /// /// <param name="id">The ID for the comment which is associated to a Movie </param>
        /// <returns>The comment corresponding to a specific id.</returns>
        /// <response code="201">Returns the comment with a specific id.</response>
        /// <response code="400">If the comment is null</response>
     
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Comment>> GetComment(long id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        /// <summary>
        /// Add or Update
        /// </summary>
        /// /// <remark>
        /// Sample request:
        /// 
        ///   PUT  /api/Comments/5
        ///   
        /// PUT/ TODO
        /// {
        /// "id": 5,
        ///"text": "string ",
        ///"important": true,
        /// "movieId": 0
        /// }
        /// </remark>
        /// <param name="comment">The updated or created Comment</param>
        /// <returns>The updated comment.</returns>
        /// <response code="201">The comment has been updated.</response>
        /// <response code="400">If the comment is null</response>   
  
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutComment(long id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        /// <summary>
        /// Add/Create a new Comment
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="comment">Comment we want to add </param>
        /// <returns>A newly created Comment item.</returns>
        /// <response code="201">Returns the newly created comment.</response>
        /// <response code="400">If the comment is null</response>            

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        /// <summary>
        /// Delete a comment with a certain id
        /// </summary>
        ///         /// /// <remarks>
        /// DELETE /api/Comments/5
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <response code="201">The comment has been deleted succesfully.</response>
        /// <response code="400">If the comment is null</response>  
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Comment>> DeleteComment(long id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(long id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
