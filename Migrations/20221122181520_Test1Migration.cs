using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroMed_API.Migrations
{
    public partial class Test1Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinBruteSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxBruteSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinISCEDLevel = table.Column<int>(type: "int", nullable: false),
                    WorkHoursPerMonth = table.Column<int>(type: "int", nullable: false),
                    AnnualPaidLeave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumEmployeesNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EmploymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeniorityYears = table.Column<int>(type: "int", nullable: false),
                    DocumentsPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AnnualPaidLeave", "Currency", "Description", "MaxBruteSalary", "MinBruteSalary", "MinISCEDLevel", "Title", "WorkHoursPerMonth" },
                values: new object[,]
                {
                    { new Guid("cdb98091-c8c1-4774-9612-57c4e6fb81f2"), 22, "RON", "It usually assists the higher grades and leads to the fulfillment of easy tasks (harvests, vaccines, etc.)", 12368m, 7094m, 6, "Nurse", 180 },
                    { new Guid("cdb98091-c8c1-4774-9612-57c4e6fb81f3"), 22, "RON", "He deals with the inventory and distribution of medicines inside unit.", 12614m, 4227m, 6, "Chemist", 180 },
                    { new Guid("cdb98091-c8c1-4774-9612-57c4e6fb81f4"), 22, "RON", "He takes care of heavy tasks. It usually represents the penultimate grade after the department head.", 26986m, 7000m, 8, "Primary doctor", 180 },
                    { new Guid("cdb98091-c8c1-4774-9612-57c4e6fb81f5"), 22, "RON", "He coordinates the whole department.", 29795m, 28795m, 8, "Head of department", 180 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Description", "MaximumEmployeesNo", "Title" },
                values: new object[,]
                {
                    { new Guid("10261ba6-d3f9-48bb-b48f-12bf7a43bb82"), "This section deals with diseas related to the heart.", 5, "Cardiology" },
                    { new Guid("10261ba6-d3f9-48bb-b48f-12bf7a43bb83"), "This section deals with diseases related to the nervous system.", 3, "Neurology" },
                    { new Guid("10261ba6-d3f9-48bb-b48f-12bf7a43bb84"), "This section deals with diseases related to the respiratory system.", 6, "Pneumology" },
                    { new Guid("10261ba6-d3f9-48bb-b48f-12bf7a43bb85"), "This section deals with radiographs.", 9, "Radiology" }
                });


            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Birthdate", "DocumentsPath", "Email", "EmploymentDate", "FirstName", "Gender", "JobId", "LastName", "Nationality", "PhoneNumber", "PlaceOfBirth", "Salary", "SectionId", "SeniorityYears" },
                values: new object[] { new Guid("0b273992-95bd-4baf-b298-92355f67b620"), "Arges, Pitesti, Strada Mioarei Nr1", new DateTimeOffset(new DateTime(1978, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "X://ToCompute", "unemail@gmail.com", new DateTimeOffset(new DateTime(2007, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Mihai", "M", new Guid("cdb98091-c8c1-4774-9612-57c4e6fb81f2"), "Calugar", "Romanian", "+40712345678", "Arges, Pitesti, Strada Mioarei Nr. 1", 7200m, new Guid("10261ba6-d3f9-48bb-b48f-12bf7a43bb82"), 4 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Birthdate", "DocumentsPath", "Email", "EmploymentDate", "FirstName", "Gender", "JobId", "LastName", "Nationality", "PhoneNumber", "PlaceOfBirth", "Salary", "SectionId", "SeniorityYears" },
                values: new object[] { new Guid("0b273992-95bd-4baf-b298-92355f67b621"), "Arges, Pitesti, Strada Mioarei Nr1", new DateTimeOffset(new DateTime(1968, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "X://ToCompute", "altemail@gmail.com", new DateTimeOffset(new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "George", "M", new Guid("cdb98091-c8c1-4774-9612-57c4e6fb81f2"), "Patrar", "Romanian", "+40723456789", "Bucurest, Sectorul 1, O strada nr 3", 29000m, new Guid("10261ba6-d3f9-48bb-b48f-12bf7a43bb83"), 22 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Birthdate", "DocumentsPath", "Email", "EmploymentDate", "FirstName", "Gender", "JobId", "LastName", "Nationality", "PhoneNumber", "PlaceOfBirth", "Salary", "SectionId", "SeniorityYears" },
                values: new object[] { new Guid("0b273992-95bd-4baf-b298-92355f67b622"), "Arges, Pitesti, Strada Mioarei Nr1", new DateTimeOffset(new DateTime(1978, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "X://ToCompute", "unemail@gmail.com", new DateTimeOffset(new DateTime(2007, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Mihai", "M", new Guid("cdb98091-c8c1-4774-9612-57c4e6fb81f3"), "Calugar", "Romanian", "+40712345678", "Arges, Pitesti, Strada Mioarei Nr. 1", 7200m, new Guid("10261ba6-d3f9-48bb-b48f-12bf7a43bb84"), 4 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Admin", "CreatedDate", "EmployeeId", "Password", "Username" },
                values: new object[] { new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9247"), false, new DateTimeOffset(new DateTime(2022, 11, 22, 20, 15, 20, 364, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 2, 0, 0, 0)), new Guid("0b273992-95bd-4baf-b298-92355f67b620"), "OParola", "UnUSername" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Admin", "CreatedDate", "EmployeeId", "Password", "Username" },
                values: new object[] { new Guid("1fdbe311-ac30-4a06-be2c-0fcc779b9248"), false, new DateTimeOffset(new DateTime(2022, 11, 22, 20, 15, 20, 364, DateTimeKind.Unspecified).AddTicks(508), new TimeSpan(0, 2, 0, 0, 0)), new Guid("0b273992-95bd-4baf-b298-92355f67b621"), "AltaParola", "AltUSername" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobId",
                table: "Employees",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SectionId",
                table: "Employees",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
