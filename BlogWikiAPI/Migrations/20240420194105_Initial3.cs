using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWikiAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_articles_ArticleId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_ArticleId",
                table: "comments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "comments");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ArticleId",
                table: "comments",
                column: "ArticleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_articles_ArticleId",
                table: "comments",
                column: "ArticleId",
                principalTable: "articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
