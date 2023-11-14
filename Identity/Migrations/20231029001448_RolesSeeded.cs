using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b44f473-919a-4e59-924a-974f4cf6d2b9", "1", "Admin", "Admin" },
                    { "533c01a2-c2ff-4c53-b6d6-2fdc336d42ad", "2", "User", "User" },
                    { "6fdde220-e8cf-40c0-8674-296c0af0ba64", "3", "HR", "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b44f473-919a-4e59-924a-974f4cf6d2b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "533c01a2-c2ff-4c53-b6d6-2fdc336d42ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fdde220-e8cf-40c0-8674-296c0af0ba64");
        }
    }
}
