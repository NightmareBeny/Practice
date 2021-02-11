using Microsoft.EntityFrameworkCore.Migrations;

namespace Тест.Migrations
{
    public partial class Email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "LogIn");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LogIn",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "False",
                table: "LogIn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "True",
                table: "LogIn",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "LogIn");

            migrationBuilder.DropColumn(
                name: "False",
                table: "LogIn");

            migrationBuilder.DropColumn(
                name: "True",
                table: "LogIn");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "LogIn",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
