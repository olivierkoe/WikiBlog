using System.ComponentModel.DataAnnotations;

namespace BlogWikiAPI.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; } = "";
        [StringLength(100, ErrorMessage = "Maximum de 100 caractères atteints !")]
        public string Description { get; set; } = "";
        public required string Author { get; set; } = "";
        public DateTime CreatedDate { get; init; }= DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public required int ArticleId { get; set;}
        public required int UserId { get; set; }
        public List<Article>? commentArticles { get; set; }
    }
}
