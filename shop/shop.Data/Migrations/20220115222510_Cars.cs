using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Data.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePathCar_Car_CarId",
                table: "ExistingFilePathCar");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePathCar_CarId",
                table: "ExistingFilePathCar");

            migrationBuilder.AddColumn<Guid>(
                name: "CarsId",
                table: "ExistingFilePathCar",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePathCar_CarsId",
                table: "ExistingFilePathCar",
                column: "CarsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePathCar_Cars_CarsId",
                table: "ExistingFilePathCar",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePathCar_Cars_CarsId",
                table: "ExistingFilePathCar");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePathCar_CarsId",
                table: "ExistingFilePathCar");

            migrationBuilder.DropColumn(
                name: "CarsId",
                table: "ExistingFilePathCar");

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePathCar_CarId",
                table: "ExistingFilePathCar",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePathCar_Car_CarId",
                table: "ExistingFilePathCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
