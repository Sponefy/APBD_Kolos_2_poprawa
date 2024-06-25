using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolos_2_poprawa.Migrations
{
    /// <inheritdoc />
    public partial class test002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "car_rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 8, 12, 532, DateTimeKind.Local).AddTicks(7720), new DateTime(2024, 6, 30, 13, 8, 12, 532, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "car_rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 8, 12, 532, DateTimeKind.Local).AddTicks(7800), new DateTime(2024, 6, 30, 13, 8, 12, 532, DateTimeKind.Local).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "car_rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CarId", "ClientId", "DateFrom", "DateTo" },
                values: new object[] { 2, 1, new DateTime(2024, 6, 25, 13, 8, 12, 532, DateTimeKind.Local).AddTicks(7800), new DateTime(2024, 6, 30, 13, 8, 12, 532, DateTimeKind.Local).AddTicks(7800) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "car_rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 25, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9770), new DateTime(2024, 6, 30, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9880) });

            migrationBuilder.UpdateData(
                table: "car_rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 25, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 6, 30, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "car_rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CarId", "ClientId", "DateFrom", "DateTo" },
                values: new object[] { 1, 2, new DateTime(2024, 6, 25, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 6, 30, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9890) });
        }
    }
}
