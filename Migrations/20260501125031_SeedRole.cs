using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace schoolApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d356e78-f155-4536-af25-ca1ed6174a7d", "93415d6a-053e-46ad-8d70-4815155b1ec8", "Student", "STUDENT" },
                    { "c25e0f08-e045-414e-a467-85753a46f3db", "3f50074f-eaf9-466d-8810-150db03f495f", "Teacher", "TEACHER" },
                    { "e5362752-c2f0-48a4-bc09-ea65c7ab8b78", "7e6f70e9-1edc-4fc0-94cb-45240306881c", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d356e78-f155-4536-af25-ca1ed6174a7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c25e0f08-e045-414e-a467-85753a46f3db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5362752-c2f0-48a4-bc09-ea65c7ab8b78");
        }
    }
}
