using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class idbinding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c3623dc-7bee-42e3-b67d-68cda4c741c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85bbad33-d5d4-491e-9942-c0aa9eda30d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0d54528-74d3-4075-aa4f-26f68eb5eeb3");

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "HrAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "EmployeeAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "AdminAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "HrAnnouncements");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "EmployeeAnnouncements");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "AdminAnnouncements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c3623dc-7bee-42e3-b67d-68cda4c741c9", "3", "HR", "HR" },
                    { "85bbad33-d5d4-491e-9942-c0aa9eda30d3", "2", "User", "User" },
                    { "b0d54528-74d3-4075-aa4f-26f68eb5eeb3", "1", "Admin", "Admin" }
                });
        }
    }
}
