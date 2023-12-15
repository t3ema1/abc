using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class allannounces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0db63630-1bf9-4258-95a6-1d7d01a1977c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a9696e-8abd-43dd-99eb-506de51903b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc75f9e3-a8a1-4c86-8a1c-46a10c8e8a0b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29ea8ce7-6a0c-4fa1-b77b-938f8f833de7", "3", "HR", "HR" },
                    { "a455bffc-63d5-4257-a31c-fe75526f9d90", "2", "User", "User" },
                    { "fcd5fea4-222e-4417-b755-90a7370f106d", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29ea8ce7-6a0c-4fa1-b77b-938f8f833de7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a455bffc-63d5-4257-a31c-fe75526f9d90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcd5fea4-222e-4417-b755-90a7370f106d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0db63630-1bf9-4258-95a6-1d7d01a1977c", "3", "HR", "HR" },
                    { "74a9696e-8abd-43dd-99eb-506de51903b6", "1", "Admin", "Admin" },
                    { "dc75f9e3-a8a1-4c86-8a1c-46a10c8e8a0b", "2", "User", "User" }
                });
        }
    }
}
