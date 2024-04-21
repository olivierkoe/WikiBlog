using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWikiAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleComment",
                columns: table => new
                {
                    articleCommentsId = table.Column<int>(type: "int", nullable: false),
                    commentArticlesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComment", x => new { x.articleCommentsId, x.commentArticlesId });
                    table.ForeignKey(
                        name: "FK_ArticleComment_articles_commentArticlesId",
                        column: x => x.commentArticlesId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleComment_comments_articleCommentsId",
                        column: x => x.articleCommentsId,
                        principalTable: "comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_commentArticlesId",
                table: "ArticleComment",
                column: "commentArticlesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleComment");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "articles");
        }
    }
}
