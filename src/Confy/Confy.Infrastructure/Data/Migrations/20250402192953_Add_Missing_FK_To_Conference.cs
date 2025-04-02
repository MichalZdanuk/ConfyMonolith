using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confy.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Missing_FK_To_Conference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ConferenceId",
                schema: "confy",
                table: "Notifications",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Conferences_ConferenceId",
                schema: "confy",
                table: "Notifications",
                column: "ConferenceId",
                principalSchema: "confy",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Conferences_ConferenceId",
                schema: "confy",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ConferenceId",
                schema: "confy",
                table: "Notifications");
        }
    }
}
