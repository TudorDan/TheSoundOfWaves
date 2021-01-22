using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LearningSite.Data.Migrations
{
    public partial class seedStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Principals",
                columns: new[] { "Id", "AccessRights", "BirthDate", "Name", "Photo", "SchoolId" },
                values: new object[] { 2, 2, new DateTime(1967, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don Guzman", "principal2.jpg", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AccessRights", "BirthDate", "CatalogueId", "Name", "Photo", "SchoolId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1999, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sister Switchblades", "student11.jpg", 1 },
                    { 5, 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jamal Gangsta LeeRoy", "student12.jpg", 1 },
                    { 9, 1, new DateTime(1989, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Donna Corason Intenso", "student21.jpg", 2 },
                    { 10, 1, new DateTime(2001, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Sleeping Student", "student22.jpg", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "Photo" },
                values: new object[] { 2, "Universidad Técnica de Buenas Maneras y Pistoleros", "school2.jpg" });

            migrationBuilder.InsertData(
                table: "Principals",
                columns: new[] { "Id", "AccessRights", "BirthDate", "Name", "Photo", "SchoolId" },
                values: new object[] { 6, 2, new DateTime(1967, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don Guzman", "principal2.jpg", 2 });
        }
    }
}
