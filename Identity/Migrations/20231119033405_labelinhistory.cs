using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class labelinhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5189df19-573c-4c11-ab76-930088819799");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b2aad06-c11f-42bd-a89d-497330fd1ccc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6af4842-f814-4369-b699-4a966a4a0278");

            migrationBuilder.AddColumn<string>(
                name: "LabelName",
                table: "AnnouncementsHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "LabelName",
                table: "AnnouncementsHistory");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5189df19-573c-4c11-ab76-930088819799", "1", "Admin", "Admin" },
                    { "7b2aad06-c11f-42bd-a89d-497330fd1ccc", "2", "User", "User" },
                    { "a6af4842-f814-4369-b699-4a966a4a0278", "3", "HR", "HR" }
                });
        }
    }
}
