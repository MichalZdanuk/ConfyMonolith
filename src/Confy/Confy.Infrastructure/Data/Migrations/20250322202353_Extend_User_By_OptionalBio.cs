using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confy.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Extend_User_By_OptionalBio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                schema: "confy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                schema: "confy",
                table: "Users");
        }
    }
}
