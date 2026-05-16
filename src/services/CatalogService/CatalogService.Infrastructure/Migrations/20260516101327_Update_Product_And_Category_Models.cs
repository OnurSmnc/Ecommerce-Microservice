using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CatalogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Product_And_Category_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Electronics" },
                    { 2, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Computers" },
                    { 3, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Accessories" },
                    { 4, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Storage" },
                    { 5, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Gaming" },
                    { 6, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Networking" },
                    { 7, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Audio" },
                    { 8, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Monitors" },
                    { 9, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Printers" },
                    { 10, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Software" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "High performance laptop", "Laptop", 85.99m, 50 },
                    { 2, 1, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Wireless optical mouse", "Mouse", 15.49m, 80 },
                    { 3, 1, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Mechanical keyboard", "Keyboard", 45.00m, 60 },
                    { 4, 2, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "27 inch 4K monitor", "Monitor", 99.99m, 30 },
                    { 5, 7, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Noise cancelling headset", "Headphones", 55.75m, 40 },
                    { 6, 3, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "1080p HD webcam", "Webcam", 29.99m, 70 },
                    { 7, 3, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "7 port USB 3.0 hub", "USB Hub", 18.50m, 90 },
                    { 8, 4, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "1TB NVMe SSD", "SSD", 72.00m, 25 },
                    { 9, 4, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "16GB DDR5 RAM", "RAM", 63.25m, 35 },
                    { 10, 5, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Gaming graphics card", "GPU", 95.00m, 15 }
                });
        }
    }
}
