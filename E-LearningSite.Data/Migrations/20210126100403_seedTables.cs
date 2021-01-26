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
                values: new object[] { 1, "Weed Health Institute", "school1.jpg" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "Photo" },
                values: new object[] { 2, "Universidad Técnica de Buenas Maneras y Pistoleros", "school2.jpg" });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[,]
                {
                    { 1, "Broncos Ist Grade", 1 },
                    { 2, "Steelers IIIrd Grade", 1 },
                    { 3, "Cowboys 9th Grade", 2 }
                });

            migrationBuilder.InsertData(
                table: "Mentors",
                columns: new[] { "Id", "AccessRights", "BirthDate", "Name", "Photo", "SchoolId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1960, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tyrone Shotgun", "mentor11.jpg", 1 },
                    { 2, 0, new DateTime(1970, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnny 3Fingers", "mentor12.jpg", 1 },
                    { 3, 0, new DateTime(1964, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric Blood Axe", "mentor21.jpg", 2 },
                    { 4, 0, new DateTime(1970, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tommy Machine Gun", "mentor22.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "Principals",
                columns: new[] { "Id", "AccessRights", "BirthDate", "Name", "Photo", "SchoolId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1950, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miss Danger", "principal1.jpg", 1 },
                    { 2, 2, new DateTime(1967, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don Guzman", "principal2.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AccessRights", "BirthDate", "CatalogueId", "Name", "Photo", "SchoolId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1999, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sister Switchblades", "student11.jpg", 1 },
                    { 5, 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jamal Gangsta LeeRoy", "student12.jpg", 1 },
                    { 10, 1, new DateTime(2001, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Sleeping Student", "student22.jpg", 2 },
                    { 9, 1, new DateTime(1989, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Donna Corason Intenso", "student21.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[,]
                {
                    { 2, "IT", 1 },
                    { 4, "IT", 2 },
                    { 1, "HISTORY", 1 },
                    { 3, "ASTRONOMY", 1 },
                    { 5, "HISTORY", 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "SchoolId", "SubjectId" },
                values: new object[,]
                {
                    { 2, "For advanced majors", "How to Watch Television", 1, 1 },
                    { 1, "Pay for 1, you get 2", "Guessing Master of Science", 1, 3 },
                    { 3, "2nd edition", "Hacking Ethics", 2, 4 },
                    { 4, "42", "The Answer to Life, The Universe and Everything", 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CourseId", "Link", "Name" },
                values: new object[,]
                {
                    { 3, 2, "Getting dressed link 1", "Getting dressed doc 1" },
                    { 4, 2, "The art of walking link 2", "The art of walking doc 2" },
                    { 1, 1, "Palm Reading link 1", "Palm Reading doc 1" },
                    { 2, 1, "Witchcraft link 2", "Witchcraft doc 2" },
                    { 5, 3, "kack link 1", "hack doc 1" },
                    { 6, 3, "hacky link 2", "hacky doc 2" },
                    { 7, 4, "Keep searching link 1", "Keep searching doc 1" },
                    { 8, 4, " link 2", " doc 2" }
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
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 1);

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
