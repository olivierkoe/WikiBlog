using BlogWikiAPI.DbContexts;
using BlogWikiAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BlogWikiAPI.Services
{
    public class ArticleDTO : IArticleDTO
    {
        private readonly BlogWikiAPIDbContext _context;
        public ArticleDTO(BlogWikiAPIDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> AddArticle(Article article)
        {
            _context.articles.Add(article);
            await _context.SaveChangesAsync();
            return await _context.articles.ToListAsync();
        }

        public async Task<List<Article>> GetAllArticles()
        {
            var articles = await _context.articles.ToListAsync();

            foreach (var article in articles)
            {

                article.articleComments = await _context.comments.Where(x => x.ArticleId == article.Id).ToListAsync();
            }

            return articles;
        }

        public async Task<Article?> GetSingleArticle(int id)
        {
            var article = await _context.articles.FindAsync(id);
            if (article == null)
            {
                return null;
            }
            article.articleComments = await _context.comments.Where(x => x.ArticleId == article.Id).ToListAsync();

            return article;
        }

        public async Task<List<Article>?> UpdateArticle(int id, Article request)
        {
            var article = await _context.articles.FindAsync(id);
            if (article == null)
            {
                return null;
            }

            article.Title = request.Title;
            article.Description = request.Description;
            article.Author = request.Author;
            article.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return await _context.articles.ToListAsync();
        }
        public async Task<List<Article>?> DeleteArticle(int id)
        {
            var article = await _context.articles.FindAsync(id);
            if (article == null)
            {
                return null;
            }
            _context.articles.Remove(article);
            await _context.SaveChangesAsync();

            return await _context.articles.ToListAsync();
        }
    }
}
