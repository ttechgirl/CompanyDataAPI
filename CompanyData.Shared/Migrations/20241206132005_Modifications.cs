using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyData.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Modifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("1eff9885-7088-4da3-9b8c-d086cfa99ee6"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("e237f904-35e4-4f31-b854-b49c61a8b443"));

            migrationBuilder.DropColumn(
                name: "Supervisor",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Employee",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Employee",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supervisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "City", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "State", "Supervisor" },
                values: new object[,]
                {
                    { new Guid("43738933-acf0-4479-8624-0ef1bec0383d"), "Houston", "HR", new DateTime(2024, 12, 6, 14, 20, 4, 874, DateTimeKind.Local).AddTicks(6173), "HR", null, "Enginearing & Product", "Texas", "paul@company.com" },
                    { new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), "Ikeja", "HR", new DateTime(2024, 12, 6, 14, 20, 4, 874, DateTimeKind.Local).AddTicks(6354), "HR", null, "Marketing & Sales", "Lagos", "Adex@company.com" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedOn", "DepartmentId", "Email", "FirstName", "JobRole", "LastName", "MiddleName", "ModifiedBy", "ModifiedOn", "PhoneNumber", "WagesInDollar" },
                values: new object[,]
                {
                    { new Guid("7713bf21-9e81-4949-abf7-d5a64f281d69"), "30 Alpha estate lekki", "HR", new DateTime(2024, 12, 6, 14, 20, 4, 874, DateTimeKind.Local).AddTicks(6772), new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), "Adex@company.com", "Michael", "Media Lead", "Adex", null, "HR", null, "0907794487", 5500.0 },
                    { new Guid("acc627bb-7733-4e13-876e-7d49a3838c12"), "8,Mesa Road", "HR", new DateTime(2024, 12, 6, 14, 20, 4, 874, DateTimeKind.Local).AddTicks(6739), new Guid("43738933-acf0-4479-8624-0ef1bec0383d"), "paul@company.com", "Isaac", "Lead", "Paul", null, "HR", null, "+1312754448", 4500.0 },
                    { new Guid("d17d52bd-9178-41d1-b399-705f6b7899b9"), "12,ogunnaike street GRA", "HR", new DateTime(2024, 12, 6, 14, 20, 4, 874, DateTimeKind.Local).AddTicks(6761), new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), "cherry@company.com", "Cherri", "Media", "Evans", "Beauty", "HR", null, "07027544487", 2500.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("7713bf21-9e81-4949-abf7-d5a64f281d69"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("acc627bb-7733-4e13-876e-7d49a3838c12"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("d17d52bd-9178-41d1-b399-705f6b7899b9"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Employee",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employee",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                newName: "IX_Employee_CompanyId");

            migrationBuilder.AddColumn<Guid>(
                name: "Supervisor",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyId",
                table: "Employee",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
