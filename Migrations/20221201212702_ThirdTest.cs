using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroMed_API.Migrations
{
    public partial class ThirdTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 1, 23, 27, 1, 405, DateTimeKind.Unspecified).AddTicks(4541), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 1, 23, 27, 1, 405, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 1, 23, 27, 1, 405, DateTimeKind.Unspecified).AddTicks(4559), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 1, 23, 21, 45, 307, DateTimeKind.Unspecified).AddTicks(1841), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 1, 23, 21, 45, 307, DateTimeKind.Unspecified).AddTicks(1852), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 12, 1, 23, 21, 45, 307, DateTimeKind.Unspecified).AddTicks(1856), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
