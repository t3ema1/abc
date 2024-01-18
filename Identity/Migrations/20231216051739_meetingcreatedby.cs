using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class meetingcreatedby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CreatedBy",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "meeting_CreatedBy",
                table: "Attendees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "meeting_CreatedBy",
                table: "Attendees");

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
    }
}
