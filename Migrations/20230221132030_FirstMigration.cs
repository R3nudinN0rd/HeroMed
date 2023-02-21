using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroMed_API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EmploymentDate",
                table: "Employees",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Birthdate",
                table: "Employees",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b600"),
                columns: new[] { "Birthdate", "EmploymentDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b620"),
                columns: new[] { "Birthdate", "EmploymentDate" },
                values: new object[] { new DateTimeOffset(new DateTime(1978, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2007, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b621"),
                columns: new[] { "Birthdate", "EmploymentDate" },
                values: new object[] { new DateTimeOffset(new DateTime(1968, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b622"),
                columns: new[] { "Birthdate", "EmploymentDate" },
                values: new object[] { new DateTimeOffset(new DateTime(1978, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2007, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b600"),
                columns: new[] { "Birthdate", "EmploymentDate" },
                values: new object[] { new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b620"),
                columns: new[] { "Birthdate", "EmploymentDate" },
                values: new object[] { new DateTime(1978, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b621"),
                columns: new[] { "Birthdate", "EmploymentDate" },
                values: new object[] { new DateTime(1968, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b273992-95bd-4baf-b298-92355f67b622"),
                columns: new[] { "Birthdate", "EmploymentDate" },
                values: new object[] { new DateTime(1978, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
    }
}
