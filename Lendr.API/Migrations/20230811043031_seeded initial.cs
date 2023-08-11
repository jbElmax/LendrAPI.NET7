using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lendr.API.Migrations
{
    /// <inheritdoc />
    public partial class seededinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CivilStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Married" },
                    { 3, "Widow" },
                    { 4, "Common Law" }
                });

            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "Id", "CivilStatusId", "FirstName", "LastName", "MiddleName", "Suffix" },
                values: new object[,]
                {
                    { 1, 2, "Jan", "Elnas", "Bongcawel", "" },
                    { 2, 2, "Grace", "Bongcawel", "Namocatcat", "" },
                    { 3, 1, "Louie Ysabelle", "Elnas", "Mariano", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CivilStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CivilStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CivilStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CivilStatuses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
