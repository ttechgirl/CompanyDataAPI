using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyData.Shared.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
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
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supervisor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WagesInDollar = table.Column<double>(type: "float", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Address", "City", "State" },
                values: new object[,]
                {
                    { new Guid("43738933-acf0-4479-8624-0ef1bec0383d"), "8,Mesa Road", "Houston", "Texas" },
                    { new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), "12,ogunnaike street GRA", "Ikeja", "Lagos" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CompanyId", "Department", "Email", "FirstName", "JobRole", "LastName", "MiddleName", "PhoneNumber", "Supervisor", "WagesInDollar" },
                values: new object[,]
                {
                    { new Guid("1eff9885-7088-4da3-9b8c-d086cfa99ee6"), new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), "Digital", "paulI@gmail.com", "Cherri", "Media", "Evans", "Beauty", "07027544487", new Guid("43738933-acf0-4479-8624-0ef1bec0383d"), 2500.0 },
                    { new Guid("e237f904-35e4-4f31-b854-b49c61a8b443"), new Guid("43738933-acf0-4479-8624-0ef1bec0383d"), "Digital", "digitalteam@gmail.com", "Isaac", "Lead", "Paul", null, "+1312754448", null, 4500.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
