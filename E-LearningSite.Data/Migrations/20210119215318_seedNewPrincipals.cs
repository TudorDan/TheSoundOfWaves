using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LearningSite.Data.Migrations
{
    public partial class seedNewPrincipals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Principals",
                columns: new[] { "Id", "AccessRights", "BirthDate", "Name", "Photo", "SchoolId" },
                values: new object[] { 1, 2, new DateTime(1950, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miss Danger", "http://localhost:54719/images/principal1.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Principals",
                columns: new[] { "Id", "AccessRights", "BirthDate", "Name", "Photo", "SchoolId" },
                values: new object[] { 6, 2, new DateTime(1967, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don Guzman", "http://localhost:54719/images/principal2.jpg", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
