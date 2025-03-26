using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confy.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Extend_User_By_FullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName_FirstName",
                schema: "confy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName_LastName",
                schema: "confy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName_FirstName",
                schema: "confy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName_LastName",
                schema: "confy",
                table: "Users");
        }
    }
}
