using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class who_created_it1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "createdby",
                table: "UserNTAstories",
                newName: "Createdby");

            migrationBuilder.RenameColumn(
                name: "createdby",
                table: "NTAstories",
                newName: "Createdby");

            migrationBuilder.RenameColumn(
                name: "createdby",
                table: "HrNTAstories",
                newName: "Createdby");

            migrationBuilder.RenameColumn(
                name: "createdby",
                table: "HrAnnouncements",
                newName: "Createdby");

            migrationBuilder.RenameColumn(
                name: "createdby",
                table: "EmployeeAnnouncements",
                newName: "Createdby");

            migrationBuilder.RenameColumn(
                name: "createdby",
                table: "Announcements",
                newName: "Createdby");

            migrationBuilder.RenameColumn(
                name: "createdby",
                table: "AdminNTAstories",
                newName: "Createdby");

            migrationBuilder.RenameColumn(
                name: "createdby",
                table: "AdminAnnouncements",
                newName: "Createdby");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66473b84-3a94-4a0a-93d6-47d709c46d9e", "1", "Admin", "Admin" },
                    { "808969c0-93aa-4831-9e5f-243a38300caf", "3", "HR", "HR" },
                    { "a08636fd-b4d7-426f-a0e4-c12705389a43", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66473b84-3a94-4a0a-93d6-47d709c46d9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808969c0-93aa-4831-9e5f-243a38300caf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a08636fd-b4d7-426f-a0e4-c12705389a43");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "UserNTAstories",
                newName: "createdby");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "NTAstories",
                newName: "createdby");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "HrNTAstories",
                newName: "createdby");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "HrAnnouncements",
                newName: "createdby");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "EmployeeAnnouncements",
                newName: "createdby");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "Announcements",
                newName: "createdby");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "AdminNTAstories",
                newName: "createdby");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "AdminAnnouncements",
                newName: "createdby");

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
    }
}
