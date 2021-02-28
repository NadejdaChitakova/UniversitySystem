using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversitySystem.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseTopic",
                columns: new[] { "Id", "Topic" },
                values: new object[] { 2, "Computer sciences" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseTopic",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
