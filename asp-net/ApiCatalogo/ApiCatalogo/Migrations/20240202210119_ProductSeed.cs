using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImgUrl", "Name", "Price", "RegisterData", "Stock" },
                values: new object[,]
                {
                    { 1L, 1L, "Fiat Punto", "https://img.com.br", "Punto", 25000.0, new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2490), 2.0 },
                    { 2L, 1L, "Ford Fiesta", "https://img.com.br", "Fiesta", 15000.0, new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2506), 1.0 },
                    { 3L, 2L, "Apple MacBook PRO", "https://img.com.br", "MacBook", 5000.0, new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2508), 10.0 },
                    { 4L, 3L, "Apple Iphone 12", "https://img.com.br", "Iphone 12", 3000.0, new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2509), 5.0 },
                    { 5L, 3L, "Galaxy S23 Ultra", "https://img.com.br", "Galaxy s23 ultra", 3000.0, new DateTime(2024, 2, 2, 18, 1, 19, 67, DateTimeKind.Local).AddTicks(2511), 3.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
