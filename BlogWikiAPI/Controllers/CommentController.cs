using BlogWikiAPI.DTOs;
using BlogWikiAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWikiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentDTO _Context;

        public CommentController(ICommentDTO commentDTO)
        {
            _Context = commentDTO;
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            var comments = await _Context.GetAllComments();

            return comments;
        }

        /// <summary>
        /// Get a comment by Id
        /// </summary>
        /// <param name="id">id comment</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetSingleComment(int id)
        {
            var comment = await _Context.GetSingleComment(id);

            if (comment == null)
            {
                return NotFound("Comment not found");
            }
            return Ok(comment);
        }

        /// <summary>
        /// Post new comment
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            var result = await _Context.AddComment(comment);
            return Ok(result);
        }

        /// <summary>
        /// Put modify a comment by Id
        /// </summary>
        /// <param name="id">id comment</param>
        /// <returns></returns>
        [HttpPut("{id}"), Authorize]
        public async Task<ActionResult<List<Comment>>> UpdateComment(int id, Comment request)
        {
            var result = await _Context.UpdateComment(id, request);
            if (result == null)
                return NotFound("Comment not found");

            return Ok(result);
        }

        /// <summary>
        /// Delete a comment by Id
        /// </summary>
        /// <param name="id">id comment</param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult<List<Comment>>> deleteComment(int id)
        {
            var result = await _Context.DeleteComment(id);
            if (result == null)
                return NotFound("Comment not found");

            return Ok(result);
        }
    }
}
