using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversitySystem.Migrations
{
    public partial class Login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Login_Full name",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Login_LoginId1",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Login_LoginId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Login_LoginId1",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_LoginId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_LoginId1",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_Full name",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_LoginId1",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "LoginId1",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Full name",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "LoginId1",
                table: "Student");

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoginId1",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Full name",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoginId1",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_LoginId",
                table: "Teacher",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_LoginId1",
                table: "Teacher",
                column: "LoginId1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Full name",
                table: "Student",
                column: "Full name");

            migrationBuilder.CreateIndex(
                name: "IX_Student_LoginId1",
                table: "Student",
                column: "LoginId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Login_Full name",
                table: "Student",
                column: "Full name",
                principalTable: "Login",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Login_LoginId1",
                table: "Student",
                column: "LoginId1",
                principalTable: "Login",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Login_LoginId",
                table: "Teacher",
                column: "LoginId",
                principalTable: "Login",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Login_LoginId1",
                table: "Teacher",
                column: "LoginId1",
                principalTable: "Login",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
