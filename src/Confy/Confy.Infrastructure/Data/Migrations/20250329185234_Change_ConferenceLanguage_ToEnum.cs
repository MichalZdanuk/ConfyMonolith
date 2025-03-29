using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confy.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Change_ConferenceLanguage_ToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language",
                schema: "confy",
                table: "Conferences",
                newName: "ConferenceLanguage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConferenceLanguage",
                schema: "confy",
                table: "Conferences",
                newName: "Language");
        }
    }
}
