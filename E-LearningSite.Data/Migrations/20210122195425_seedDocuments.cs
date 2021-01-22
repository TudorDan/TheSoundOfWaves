using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LearningSite.Data.Migrations
{
    public partial class seedDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CourseId", "Link", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Palm Reading link 1", "Palm Reading doc 1" },
                    { 2, 1, "Witchcraft link 2", "Witchcraft doc 2" },
                    { 3, 2, "Getting dressed link 1", "Getting dressed doc 1" },
                    { 4, 2, "The art of walking link 2", "The art of walking doc 2" },
                    { 5, 3, "kack link 1", "hack doc 1" },
                    { 6, 4, "hacky link 2", "hacky doc 2" },
                    { 7, 4, "Keep searching link 1", "Keep searching doc 1" },
                    { 8, 4, " link 2", " doc 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
