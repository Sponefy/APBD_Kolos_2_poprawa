using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolos_2_poprawa.Migrations
{
    /// <inheritdoc />
    public partial class test001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cars_models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "car_rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_rentals_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_car_rentals_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "Id", "Address", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Koszykowa 63", "Jan", "Kowalski" },
                    { 2, "Złota 44", "Anna", "Nowa" }
                });

            migrationBuilder.InsertData(
                table: "colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "red" },
                    { 2, "black" },
                    { 3, "white" }
                });

            migrationBuilder.InsertData(
                table: "models",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mazda" },
                    { 2, "Toyota" },
                    { 3, "Skoda" },
                    { 4, "Ford" }
                });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "Id", "ColorId", "ModelId", "Name", "PricePerDay", "Seats", "VIN" },
                values: new object[,]
                {
                    { 1, 3, 2, "Toyota Yaris", 120, 5, "2D4HN11EX9R686008" },
                    { 2, 2, 3, "Skoda Fabia Estate", 170, 5, "JTDBR32E630013672" }
                });

            migrationBuilder.InsertData(
                table: "car_rentals",
                columns: new[] { "Id", "CarId", "ClientId", "DateFrom", "DateTo", "Discount", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 6, 25, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9770), new DateTime(2024, 6, 30, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9880), null, 480 },
                    { 2, 1, 1, new DateTime(2024, 6, 25, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 6, 30, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9890), 50, 240 },
                    { 3, 1, 2, new DateTime(2024, 6, 25, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 6, 30, 12, 42, 55, 203, DateTimeKind.Local).AddTicks(9890), null, 1700 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_rentals_CarId",
                table: "car_rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_car_rentals_ClientId",
                table: "car_rentals",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_ColorId",
                table: "cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_ModelId",
                table: "cars",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car_rentals");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "models");
        }
    }
}
