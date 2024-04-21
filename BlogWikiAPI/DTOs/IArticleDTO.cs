using BlogWikiAPI.Models;

namespace BlogWikiAPI.Services
{
    public interface IArticleDTO
    {
        Task<List<Article>> AddArticle(Article article);
        Task<List<Article>> GetAllArticles();
        Task<Article?> GetSingleArticle(int id);
        Task<List<Article>?> UpdateArticle(int id, Article article);
        Task<List<Article>?> DeleteArticle(int id);
    }
}
