using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class who_created_it : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fc3e54e-3a67-4691-bd80-6a0198ff9dd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccfd0912-3ab5-447a-82b6-1e5dde8df6f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8ec0ae9-71bf-436a-b432-a5949a64e757");

            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "UserNTAstories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "NTAstories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "HrNTAstories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "HrAnnouncements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "EmployeeAnnouncements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "AdminNTAstories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "AdminAnnouncements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f10bd0e-d80a-4f7e-92c3-fdb375716911", "3", "HR", "HR" },
                    { "9896d036-67a5-4cb5-a6dc-bb878f7cf849", "2", "User", "User" },
                    { "d5246cef-3370-47fb-b4ae-ab913fad6344", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f10bd0e-d80a-4f7e-92c3-fdb375716911");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9896d036-67a5-4cb5-a6dc-bb878f7cf849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5246cef-3370-47fb-b4ae-ab913fad6344");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "UserNTAstories");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "NTAstories");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "HrNTAstories");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "HrAnnouncements");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "EmployeeAnnouncements");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "AdminNTAstories");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "AdminAnnouncements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fc3e54e-3a67-4691-bd80-6a0198ff9dd8", "2", "User", "User" },
                    { "ccfd0912-3ab5-447a-82b6-1e5dde8df6f9", "1", "Admin", "Admin" },
                    { "d8ec0ae9-71bf-436a-b432-a5949a64e757", "3", "HR", "HR" }
                });
        }
    }
}
