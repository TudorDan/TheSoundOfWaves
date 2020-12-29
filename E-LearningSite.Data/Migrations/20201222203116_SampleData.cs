using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LearningSite.Data.Migrations
{
    public partial class SampleData : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
