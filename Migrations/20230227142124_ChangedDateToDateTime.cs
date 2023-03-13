using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroMed_API.Migrations
{
    public partial class ChangedDateToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrolledDate",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DischargeDate",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "Employees",
                type: "datetime",
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
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7b7e16ec-2672-4360-ad3d-4941d5d08742"),
                columns: new[] { "BirthDate", "DischargeDate", "EnrolledDate" },
                values: new object[] { new DateTime(1999, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7b7e16ec-2672-4360-ad3d-4941d5d08743"),
                columns: new[] { "BirthDate", "DischargeDate", "EnrolledDate" },
                values: new object[] { new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7b7e16ec-2672-4360-ad3d-4941d5d08744"),
                columns: new[] { "BirthDate", "DischargeDate", "EnrolledDate" },
                values: new object[] { new DateTime(2001, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EnrolledDate",
                table: "Patient",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DischargeDate",
                table: "Patient",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "BirthDate",
                table: "Patient",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EmploymentDate",
                table: "Employees",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Birthdate",
                table: "Employees",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

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
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7b7e16ec-2672-4360-ad3d-4941d5d08742"),
                columns: new[] { "BirthDate", "DischargeDate", "EnrolledDate" },
                values: new object[] { new DateTimeOffset(new DateTime(1999, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7b7e16ec-2672-4360-ad3d-4941d5d08743"),
                columns: new[] { "BirthDate", "DischargeDate", "EnrolledDate" },
                values: new object[] { new DateTimeOffset(new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7b7e16ec-2672-4360-ad3d-4941d5d08744"),
                columns: new[] { "BirthDate", "DischargeDate", "EnrolledDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2001, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

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
    }
}
