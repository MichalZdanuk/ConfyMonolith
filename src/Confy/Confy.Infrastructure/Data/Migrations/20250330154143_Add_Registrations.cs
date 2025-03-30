using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confy.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Registrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrations",
                schema: "confy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalSchema: "confy",
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrations_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "confy",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ConferenceId",
                schema: "confy",
                table: "Registrations",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_UserId_ConferenceId",
                schema: "confy",
                table: "Registrations",
                columns: new[] { "UserId", "ConferenceId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations",
                schema: "confy");
        }
    }
}
