using BlogWikiAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace BlogWikiAPI.DbContexts
{
    public class BlogWikiAPIDbContext : IdentityDbContext
    {
        public BlogWikiAPIDbContext(DbContextOptions<BlogWikiAPIDbContext> options) : base(options)
        {

        }

        public DbSet<Article> articles { get; set; }
        public DbSet<Comment> comments { get; set; }

    }
}
