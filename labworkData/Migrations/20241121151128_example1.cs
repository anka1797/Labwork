using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace labworkWebApp.Migrations
{
    /// <inheritdoc />
    public partial class example1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nameGenre",
                table: "GameGenres",
                newName: "Genre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "GameGenres",
                newName: "nameGenre");
        }
    }
}
