using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyData.Shared.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("7713bf21-9e81-4949-abf7-d5a64f281d69"),
                column: "Gender",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("acc627bb-7733-4e13-876e-7d49a3838c12"),
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("d17d52bd-9178-41d1-b399-705f6b7899b9"),
                column: "Gender",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employee");
        }
    }
}
