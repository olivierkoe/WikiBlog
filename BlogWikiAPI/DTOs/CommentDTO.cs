using BlogWikiAPI.DbContexts;
using BlogWikiAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Windows.Input;
using System.Xml.Linq;

namespace BlogWikiAPI.DTOs
{
    public class CommentDTO : ICommentDTO
    {
        private readonly BlogWikiAPIDbContext _context;
        public CommentDTO(BlogWikiAPIDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> AddComment(Comment comment)
        {
            _context.comments.Add(comment);
            await _context.SaveChangesAsync();
            return await _context.comments.ToListAsync();
        }

        public async Task<List<Comment>> GetAllComments()
        {
            var comments = await _context.comments.ToListAsync();

            return comments;
        }

        public async Task<Comment> GetSingleComment(int id)
        {
            var comment = await _context.comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            comment.commentArticles = await _context.articles.Where(x => x.CommentId == comment.Id).ToListAsync();

            return comment;
        }

        public async Task<List<Comment>?> UpdateComment(int id, Comment request)
        {
            var comment = await _context.comments.FindAsync(id);
            if (comment == null)
            {   
                return null;
            }

            comment.Title = request.Title;
            comment.Description = request.Description;
            comment.Author = request.Author;
            comment.ArticleId= request.ArticleId;
            comment.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return await _context.comments.ToListAsync();
        }
        public async Task<List<Comment>?> DeleteComment(int id)
        {
            var comment = await _context.comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            _context.comments.Remove(comment);
            await _context.SaveChangesAsync();

            return await _context.comments.ToListAsync();
        }
    }
}
