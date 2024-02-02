using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class ActualizationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "RegisterData",
                table: "Products",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 2, 18, 58, 41, 550, DateTimeKind.Unspecified).AddTicks(3754), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 2, 18, 58, 41, 550, DateTimeKind.Unspecified).AddTicks(3797), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 2, 18, 58, 41, 550, DateTimeKind.Unspecified).AddTicks(3801), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 2, 18, 58, 41, 550, DateTimeKind.Unspecified).AddTicks(3803), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "RegisterData",
                value: new DateTimeOffset(new DateTime(2024, 2, 2, 18, 58, 41, 550, DateTimeKind.Unspecified).AddTicks(3807), new TimeSpan(0, -3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterData",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegisterData",
                value: new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegisterData",
                value: new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RegisterData",
                value: new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "RegisterData",
                value: new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "RegisterData",
                value: new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2511));
        }
    }
}
