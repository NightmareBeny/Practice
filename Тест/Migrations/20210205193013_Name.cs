using Microsoft.EntityFrameworkCore.Migrations;

namespace Тест.Migrations
{
    public partial class Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "LogIn");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "LogIn",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "LogIn",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LogIn",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "LogIn");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LogIn");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "LogIn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "LogIn",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
