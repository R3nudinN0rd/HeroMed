using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroMed_API.Migrations
{
    public partial class _2SV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                columns: new[] { "CreatedDate", "Email" },
                values: new object[] { new DateTime(2023, 3, 2, 16, 13, 49, 487, DateTimeKind.Local).AddTicks(8117), "email@email.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                columns: new[] { "CreatedDate", "Email" },
                values: new object[] { new DateTime(2023, 3, 2, 16, 13, 49, 487, DateTimeKind.Local).AddTicks(8159), "UnUSername@altuser.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                columns: new[] { "CreatedDate", "Email" },
                values: new object[] { new DateTime(2023, 3, 2, 16, 13, 49, 487, DateTimeKind.Local).AddTicks(8163), "AltUSername@unuser.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                columns: new[] { "CreatedDate", "Password", "Username" },
                values: new object[] { new DateTime(2023, 2, 28, 13, 59, 58, 601, DateTimeKind.Local).AddTicks(8462), "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                columns: new[] { "CreatedDate", "Password", "Username" },
                values: new object[] { new DateTime(2023, 2, 28, 13, 59, 58, 601, DateTimeKind.Local).AddTicks(8509), "OParola", "UnUSername" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                columns: new[] { "CreatedDate", "Password", "Username" },
                values: new object[] { new DateTime(2023, 2, 28, 13, 59, 58, 601, DateTimeKind.Local).AddTicks(8512), "AltaParola", "AltUSername" });
        }
    }
}
