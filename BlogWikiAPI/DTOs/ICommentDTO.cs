using BlogWikiAPI.Models;

namespace BlogWikiAPI.DTOs
{
    public interface ICommentDTO
    {
        Task<Comment> GetSingleComment(int id);
        Task<List<Comment>> GetAllComments();
        Task<List<Comment>> AddComment(Comment comment);
        Task<List<Comment>?> UpdateComment(int id, Comment comment);
        Task<List<Comment>?> DeleteComment(int id);
    }
}
