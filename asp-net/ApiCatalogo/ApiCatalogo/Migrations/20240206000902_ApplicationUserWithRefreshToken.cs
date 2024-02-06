using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserWithRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 21, 9, 1, 265, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 21, 9, 1, 265, DateTimeKind.Unspecified).AddTicks(8284), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 21, 9, 1, 265, DateTimeKind.Unspecified).AddTicks(8287), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 21, 9, 1, 265, DateTimeKind.Unspecified).AddTicks(8289), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 21, 9, 1, 265, DateTimeKind.Unspecified).AddTicks(8291), new TimeSpan(0, -3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 13, 57, 3, 151, DateTimeKind.Unspecified).AddTicks(5104), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 13, 57, 3, 151, DateTimeKind.Unspecified).AddTicks(5141), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 13, 57, 3, 151, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 13, 57, 3, 151, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 5, 13, 57, 3, 151, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
