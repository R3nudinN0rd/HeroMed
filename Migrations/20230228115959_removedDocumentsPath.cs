using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroMed_API.Migrations
{
    public partial class removedDocumentsPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentsPath",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 28, 13, 59, 58, 601, DateTimeKind.Local).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 28, 13, 59, 58, 601, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 28, 13, 59, 58, 601, DateTimeKind.Local).AddTicks(8512));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentsPath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b600"),
                column: "DocumentsPath",
                value: "X://ToCompute");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b620"),
                column: "DocumentsPath",
                value: "X://ToCompute");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b621"),
                column: "DocumentsPath",
                value: "X://ToCompute");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b622"),
                column: "DocumentsPath",
                value: "X://ToCompute");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 27, 16, 21, 24, 102, DateTimeKind.Local).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 27, 16, 21, 24, 102, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 27, 16, 21, 24, 102, DateTimeKind.Local).AddTicks(3711));
        }
    }
}
