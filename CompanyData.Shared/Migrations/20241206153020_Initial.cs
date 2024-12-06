using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyData.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supervisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WagesInDollar = table.Column<double>(type: "float", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "Supervisor" },
                values: new object[,]
                {
                    { new Guid("43738933-acf0-4479-8624-0ef1bec0383d"), "HR", null, "HR", null, "Engineering & Product", "paul@company.com" },
                    { new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), "HR", null, "HR", null, "Marketing & Sales", "Adex@company.com" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Address", "City", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Email", "FirstName", "IsDeleted", "JobRole", "LastName", "MiddleName", "ModifiedBy", "ModifiedOn", "PhoneNumber", "State", "WagesInDollar" },
                values: new object[,]
                {
                    { new Guid("7713bf21-9e81-4949-abf7-d5a64f281d69"), "30 Alpha estate lekki", "Ikeja", "HR", null, "HR", null, new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), "Adex@company.com", "Michael", false, "Media Lead", "Adex", null, "HR", null, "0907794487", "Lagos", 5500.0 },
                    { new Guid("acc627bb-7733-4e13-876e-7d49a3838c12"), "8,Mesa Road", "Houston", "HR", null, "HR", null, new Guid("43738933-acf0-4479-8624-0ef1bec0383d"), "paul@company.com", "Isaac", false, "Tech Lead", "Paul", null, "HR", null, "+1312754448", "Texas", 4500.0 },
                    { new Guid("d17d52bd-9178-41d1-b399-705f6b7899b9"), "12,ogunnaike street GRA", "Ikeja", "HR", null, "HR", null, new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), "cherry@company.com", "Cherri", false, "Media", "Evans", "Beauty", "HR", null, "07027544487", "Lagos", 2500.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
