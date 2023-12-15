using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class lastannounce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AdminAnnouncements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAnnouncements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAnnouncements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAnnouncements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HrAnnouncements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAnnouncements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c03336e9-ed0c-4386-ad06-ad6f3388c063", "3", "HR", "HR" },
                    { "d0519899-1b0a-4f15-9003-2789c48b3600", "1", "Admin", "Admin" },
                    { "e3e85e26-d318-41c8-b271-ce9660f27ce6", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAnnouncements");

            migrationBuilder.DropTable(
                name: "EmployeeAnnouncements");

            migrationBuilder.DropTable(
                name: "HrAnnouncements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c03336e9-ed0c-4386-ad06-ad6f3388c063");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0519899-1b0a-4f15-9003-2789c48b3600");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3e85e26-d318-41c8-b271-ce9660f27ce6");

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
    }
}
