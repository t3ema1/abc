using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class ntastoryfirsttrial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09301ebb-88a6-4bae-9f93-d82d892c633e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "199ed62f-f613-4767-a55a-0056a9396d2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b428fc17-a587-416b-b558-69f6e2cb0cd0");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09301ebb-88a6-4bae-9f93-d82d892c633e", "3", "HR", "HR" },
                    { "199ed62f-f613-4767-a55a-0056a9396d2d", "2", "User", "User" },
                    { "b428fc17-a587-416b-b558-69f6e2cb0cd0", "1", "Admin", "Admin" }
                });
        }
    }
}
