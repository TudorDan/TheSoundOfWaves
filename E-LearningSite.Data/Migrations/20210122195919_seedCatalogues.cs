using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LearningSite.Data.Migrations
{
    public partial class seedCatalogues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 1, "Broncos Ist Grade", 1 });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 2, "Steelers IIIrd Grade", 1 });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 3, "Cowboys 9th Grade", 2 });
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
        }
    }
}
