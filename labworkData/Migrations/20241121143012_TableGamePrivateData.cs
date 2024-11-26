using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace labworkWebApp.Migrations
{
    /// <inheritdoc />
    public partial class TableGamePrivateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Access",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Games");
        }
    }
}
