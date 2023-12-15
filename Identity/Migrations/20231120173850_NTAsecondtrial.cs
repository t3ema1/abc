using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class NTAsecondtrial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f20d7f4-7e5e-453b-bd4d-c206ba289005");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c53c141-21fe-4463-a420-4d1ce985083b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1bbddcf-6a6e-4f0e-9681-0807297646cd");

            migrationBuilder.CreateTable(
                name: "AdminNTAstories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorytId = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedTo = table.Column<int>(type: "int", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminNTAstories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HrNTAstories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorytId = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedTo = table.Column<int>(type: "int", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrNTAstories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTAstories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedTo = table.Column<int>(type: "int", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTAstories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNTAstories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorytId = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedTo = table.Column<int>(type: "int", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNTAstories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40ba73f9-b961-484f-9a6f-515298490dc6", "1", "Admin", "Admin" },
                    { "b1df5155-7352-49b0-b191-e6b46615e397", "3", "HR", "HR" },
                    { "ee595b90-276f-4912-abe0-abbe198a8a27", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminNTAstories");

            migrationBuilder.DropTable(
                name: "HrNTAstories");

            migrationBuilder.DropTable(
                name: "NTAstories");

            migrationBuilder.DropTable(
                name: "UserNTAstories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40ba73f9-b961-484f-9a6f-515298490dc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1df5155-7352-49b0-b191-e6b46615e397");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee595b90-276f-4912-abe0-abbe198a8a27");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f20d7f4-7e5e-453b-bd4d-c206ba289005", "1", "Admin", "Admin" },
                    { "7c53c141-21fe-4463-a420-4d1ce985083b", "3", "HR", "HR" },
                    { "a1bbddcf-6a6e-4f0e-9681-0807297646cd", "2", "User", "User" }
                });
        }
    }
}
