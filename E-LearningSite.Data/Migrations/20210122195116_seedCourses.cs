using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LearningSite.Data.Migrations
{
    public partial class seedCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CatalogueId", "Description", "Name", "SchoolId", "SubjectId" },
                values: new object[] { 1, null, "Pay for 1, you get 2", "Guessing Master of Science", 1, 3 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CatalogueId", "Description", "Name", "SchoolId", "SubjectId" },
                values: new object[] { 2, null, "For advanced majors", "How to Watch Television", 1, 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CatalogueId", "Description", "Name", "SchoolId", "SubjectId" },
                values: new object[] { 3, null, "2nd edition", "Hacking Ethics", 2, 4 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CatalogueId", "Description", "Name", "SchoolId", "SubjectId" },
                values: new object[] { 4, null, "42", "The Answer to Life, The Universe and Everything", 2, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
