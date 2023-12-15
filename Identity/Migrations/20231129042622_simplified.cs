using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class simplified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a094af4-3abb-445d-abe9-6839714ba49b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9224cba3-44df-4f27-ad14-9283e6abce65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e63f9abf-d56e-4200-a087-64432bc0d14f");

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerializedAttendeeUsernames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendees_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46d52394-f88a-4feb-9763-16c4e5778b63", "2", "User", "User" },
                    { "52e60977-1632-4dd6-b144-6592113fd05b", "3", "HR", "HR" },
                    { "f366c98e-119e-4373-b655-a8e26800bbab", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_MeetingId",
                table: "Attendees",
                column: "MeetingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d52394-f88a-4feb-9763-16c4e5778b63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52e60977-1632-4dd6-b144-6592113fd05b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f366c98e-119e-4373-b655-a8e26800bbab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a094af4-3abb-445d-abe9-6839714ba49b", "2", "User", "User" },
                    { "9224cba3-44df-4f27-ad14-9283e6abce65", "1", "Admin", "Admin" },
                    { "e63f9abf-d56e-4200-a087-64432bc0d14f", "3", "HR", "HR" }
                });
        }
    }
}
