using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AllTablesAddcodeURCColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "WorkType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "Positions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "OrderTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "MainTimeSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "IdentityCards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codeUR",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "WorkType");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "MainTimeSheets");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "IdentityCards");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "codeUR",
                table: "Companies");
        }
    }
}
