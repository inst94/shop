using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Data.Migrations
{
    public partial class FileToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Cars_CarsId",
                table: "ExistingFilePath");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_CarsId",
                table: "ExistingFilePath");

            migrationBuilder.DropColumn(
                name: "CarsId",
                table: "ExistingFilePath");

            migrationBuilder.CreateTable(
                name: "FileToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabase", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabase");

            migrationBuilder.AddColumn<Guid>(
                name: "CarsId",
                table: "ExistingFilePath",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_CarsId",
                table: "ExistingFilePath",
                column: "CarsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Cars_CarsId",
                table: "ExistingFilePath",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
