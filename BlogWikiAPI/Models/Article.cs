
using System.ComponentModel.DataAnnotations;

namespace BlogWikiAPI.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; } = "";
        public required string Description { get; set; } = "";
        public required string Author { get; set; } = "";
        public DateTime CreatedDate { get; init; }= DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set;}
        public int? CommentId { get; set; }
        public List<Comment>? articleComments { get; set; }
    }
}
