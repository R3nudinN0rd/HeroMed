using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroMed_API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalonNumber",
                table: "Salon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Salon",
                keyColumn: "Id",
                keyValue: new Guid("46589e47-e79f-417f-9e1a-410dd719f0e6"),
                column: "SalonNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Salon",
                keyColumn: "Id",
                keyValue: new Guid("46589e47-e79f-417f-9e1a-410dd719f0e7"),
                column: "SalonNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Salon",
                keyColumn: "Id",
                keyValue: new Guid("46589e47-e79f-417f-9e1a-410dd719f0e8"),
                column: "SalonNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 21, 16, 18, 23, 357, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 21, 16, 18, 23, 357, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 21, 16, 18, 23, 357, DateTimeKind.Local).AddTicks(5165));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalonNumber",
                table: "Salon");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 21, 15, 20, 30, 221, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 21, 15, 20, 30, 221, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 21, 15, 20, 30, 221, DateTimeKind.Local).AddTicks(2388));
        }
    }
}
