using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class datesetbyuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eadc957-81e3-4378-a7d3-04c8b42f80f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea3fd0fc-e75a-4847-bd3a-bf6a53babdb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fee76325-618a-4e28-9873-4a128a6c78f8");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnnouncementDate",
                table: "HrAnnouncements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AnnouncementDate",
                table: "EmployeeAnnouncements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AnnouncementDate",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AnnouncementDate",
                table: "AdminAnnouncements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AnnouncementDate",
                table: "HrAnnouncements");

            migrationBuilder.DropColumn(
                name: "AnnouncementDate",
                table: "EmployeeAnnouncements");

            migrationBuilder.DropColumn(
                name: "AnnouncementDate",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "AnnouncementDate",
                table: "AdminAnnouncements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9eadc957-81e3-4378-a7d3-04c8b42f80f5", "1", "Admin", "Admin" },
                    { "ea3fd0fc-e75a-4847-bd3a-bf6a53babdb5", "2", "User", "User" },
                    { "fee76325-618a-4e28-9873-4a128a6c78f8", "3", "HR", "HR" }
                });
        }
    }
}
