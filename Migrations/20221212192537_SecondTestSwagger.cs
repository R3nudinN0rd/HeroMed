using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroMed_API.Migrations
{
    public partial class SecondTestSwagger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 12, 21, 25, 36, 967, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 12, 21, 25, 36, 967, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 12, 21, 25, 36, 967, DateTimeKind.Local).AddTicks(9081));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 12, 15, 59, 21, 936, DateTimeKind.Unspecified).AddTicks(9075), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 12, 15, 59, 21, 936, DateTimeKind.Unspecified).AddTicks(9153), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 12, 15, 59, 21, 936, DateTimeKind.Unspecified).AddTicks(9156), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
