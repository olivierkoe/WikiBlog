using BlogWikiAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BlogWikiAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace BlogWikiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleDTO _context;

        public ArticleController(IArticleDTO Context)
        {
            _context = Context;
        }

        /// <summary>
        /// Get article all article
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetAllArticles()
        {
            return await _context.GetAllArticles();
        }

        /// <summary>
        /// Get article all article
        /// </summary>
        /// <param name="id">id article</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetSingleArticle(int id)
        {
            var article = await _context.GetSingleArticle(id);

            if (article == null)
            {
                return NotFound("Article not found");
            }

            return Ok(article);
        }

        /// <summary>
        /// Post new article 
        /// </summary>
        /// <param name="id">article</param>
        /// <returns></returns>
        [HttpPost, Authorize]
        public async Task<ActionResult<List<Article>>> AddArticle(Article article)
        {
            var result = await _context.AddArticle(article);
            return Ok(result);
        }

        /// <summary>
        /// Put Update a article by id
        /// </summary>
        /// <param name="id">id article</param>
        /// <returns></returns>
        [HttpPut("{id}"), Authorize]
        public async Task<ActionResult<List<Article>>> UpdateArticle(int id, Article request)
        {
            var result = await _context.UpdateArticle(id, request);
            if (result == null)
                return NotFound("Article not found");

            return Ok(result);
        }

        /// <summary>
        /// Delete an article by id
        /// </summary>
        /// <param name="id">id article</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Article>>> deleteArticle(int id)
        {
            var result = await _context.DeleteArticle(id);
            if (result == null)
                return NotFound("Article not found");

            return Ok(result);
        }
    }
}
