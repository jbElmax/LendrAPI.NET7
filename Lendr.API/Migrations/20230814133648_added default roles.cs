using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lendr.API.Migrations
{
    /// <inheritdoc />
    public partial class addeddefaultroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26826610-3c1e-4f30-981e-f3c9b43a8451", null, "Administrator", "ADMINISTRATOR" },
                    { "e4a014df-fa0f-45f7-9abc-9f157fb44b5d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26826610-3c1e-4f30-981e-f3c9b43a8451");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4a014df-fa0f-45f7-9abc-9f157fb44b5d");
        }
    }
}
