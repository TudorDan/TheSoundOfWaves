using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LearningSite.Data.Migrations
{
    public partial class seedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "Photo" },
                values: new object[] { 1, "Harvard", "school1.jpg" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "Photo" },
                values: new object[] { 2, "Oxford", "school2.jpg" });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[,]
                {
                    { 1, "9th Grade - Mathematics Informatics", 1 },
                    { 2, "10th Grade - Science", 1 },
                    { 3, "9th Grade - Philosophy", 2 }
                });

            migrationBuilder.InsertData(
                table: "Mentors",
                columns: new[] { "Id", "AccessRights", "BirthDate", "Name", "Photo", "SchoolId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1960, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcel Popescu", "mentor11.jpg", 1 },
                    { 2, 0, new DateTime(1970, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Barbu", "mentor12.jpg", 1 },
                    { 3, 0, new DateTime(1980, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iulain Apostol", "mentor13.jpg", 1 },
                    { 6, 0, new DateTime(1966, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Pavel", "mentor23.jpg", 2 },
                    { 5, 0, new DateTime(1970, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emanuel Aramitu", "mentor22.jpg", 2 },
                    { 4, 0, new DateTime(1964, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric Angelescu", "mentor21.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "Principals",
                columns: new[] { "Id", "AccessRights", "BirthDate", "Name", "Photo", "SchoolId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1950, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgiana Ionescu", "principal1.jpg", 1 },
                    { 2, 2, new DateTime(1967, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marian Stanciulescu", "principal2.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AccessRights", "BirthDate", "CatalogueId", "Name", "Photo", "SchoolId" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(2000, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "George Iordanescu", "student14.jpg", 1 },
                    { 6, 1, new DateTime(2000, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Andreea Popescu", "student23.jpg", 2 },
                    { 2, 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Costin Constantinescu", "student12.jpg", 1 },
                    { 1, 1, new DateTime(1999, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elena Diaconescu", "student11.jpg", 1 },
                    { 5, 1, new DateTime(2001, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dorian Stefan", "student22.jpg", 2 },
                    { 4, 1, new DateTime(1989, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diana Petrache", "student21.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[,]
                {
                    { 4, "HISTORY", 2 },
                    { 3, "ASTRONOMY", 1 },
                    { 2, "IT", 1 },
                    { 1, "HISTORY", 1 },
                    { 5, "IT", 2 },
                    { 6, "ASTRONOMY", 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "SchoolId", "SubjectId" },
                values: new object[,]
                {
                    { 2, "Basic elements of OOP", "OOP", 1, 2 },
                    { 1, "Discover the elements of the solar system", "Solar System", 1, 3 },
                    { 4, "Political, Economic and Diplomatic Causes in the Far East", "World Word II", 2, 4 },
                    { 3, "Basic elements of cyber security", "Cyber Security", 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CourseId", "Link", "Name" },
                values: new object[,]
                {
                    { 3, 2, "Link 1", "Classes and Methods" },
                    { 4, 2, "Link 2", "Overload and Override" },
                    { 1, 1, "Link 1", "Planets of the Solar system" },
                    { 2, 1, "Link 2", "Natural satellites" },
                    { 7, 4, "Link 1", "Chinese Warlords, Kuomintang and Marco Polo Incident(1937)" },
                    { 8, 4, "Link 2", "Soviet–Japanese border interests and the Battle of Khalkin Gol(1939)" },
                    { 5, 3, "Link 1", "Malware" },
                    { 6, 3, "Link 2", "Data breaches" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 8);

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

            migrationBuilder.DeleteData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 1);

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
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
