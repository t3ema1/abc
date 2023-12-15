using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class simplified2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "SerializedAttendeeUsernames",
                table: "Meetings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "259ab8f5-9ec2-4415-aa65-b4e3ea14a986", "2", "User", "User" },
                    { "3d4594bc-5731-474f-97e1-57f085015de2", "3", "HR", "HR" },
                    { "4754a8da-741e-4a01-a46f-f1504efcdfd1", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "259ab8f5-9ec2-4415-aa65-b4e3ea14a986");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d4594bc-5731-474f-97e1-57f085015de2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4754a8da-741e-4a01-a46f-f1504efcdfd1");

            migrationBuilder.AddColumn<string>(
                name: "SerializedAttendeeUsernames",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46d52394-f88a-4feb-9763-16c4e5778b63", "2", "User", "User" },
                    { "52e60977-1632-4dd6-b144-6592113fd05b", "3", "HR", "HR" },
                    { "f366c98e-119e-4373-b655-a8e26800bbab", "1", "Admin", "Admin" }
                });
        }
    }
}
