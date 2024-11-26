using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace labworkWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ex3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "GameGenres",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GameGenres",
                newName: "Genre");
        }
    }
}
