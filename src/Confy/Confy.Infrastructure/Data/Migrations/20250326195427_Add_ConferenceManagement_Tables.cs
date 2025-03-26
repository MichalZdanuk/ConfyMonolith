using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confy.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_ConferenceManagement_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                schema: "confy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConferenceDetails_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConferenceDetails_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConferenceDetails_IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    ConferenceDetails_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConferenceLinks_FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConferenceLinks_InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConferenceLinks_WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prelegents",
                schema: "confy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prelegents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                schema: "confy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureDetails_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureDetails_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LectureDetails_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalSchema: "confy",
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureAssignments",
                schema: "confy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LectureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrelegentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureAssignments_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalSchema: "confy",
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureAssignments_Prelegents_PrelegentId",
                        column: x => x.PrelegentId,
                        principalSchema: "confy",
                        principalTable: "Prelegents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LectureAssignments_LectureId",
                schema: "confy",
                table: "LectureAssignments",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureAssignments_PrelegentId",
                schema: "confy",
                table: "LectureAssignments",
                column: "PrelegentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_ConferenceId",
                schema: "confy",
                table: "Lectures",
                column: "ConferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureAssignments",
                schema: "confy");

            migrationBuilder.DropTable(
                name: "Lectures",
                schema: "confy");

            migrationBuilder.DropTable(
                name: "Prelegents",
                schema: "confy");

            migrationBuilder.DropTable(
                name: "Conferences",
                schema: "confy");
        }
    }
}
