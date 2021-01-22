using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LearningSite.Data.Migrations
{
    public partial class seedMentors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mentors",
                columns: new[] { "Id", "AccessRights", "BirthDate", "CatalogueId", "Name", "Photo", "SchoolId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1960, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tyrone Shotgun", "mentor11.jpg", 1 },
                    { 2, 0, new DateTime(1970, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Johnny 3Fingers", "mentor12.jpg", 1 },
                    { 3, 0, new DateTime(1964, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eric Blood Axe", "mentor21.jpg", 2 },
                    { 4, 0, new DateTime(1970, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tommy Machine Gun", "mentor22.jpg", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "principal1.jpg");

            migrationBuilder.UpdateData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 6,
                column: "Photo",
                value: "principal2.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "http://localhost:54719/images/principal1.jpg");

            migrationBuilder.UpdateData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 6,
                column: "Photo",
                value: "http://localhost:54719/images/principal2.jpg");
        }
    }
}
