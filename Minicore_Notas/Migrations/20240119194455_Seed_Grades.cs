using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Minicore_Notas.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Grades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Date", "GradeValue", "Name", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 10, 1), 8.5, "Deber 1", 1 },
                    { 2, new DateOnly(2023, 10, 2), 9.5, "Prueba 1", 1 },
                    { 3, new DateOnly(2023, 10, 3), 10.0, "Control 1", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
