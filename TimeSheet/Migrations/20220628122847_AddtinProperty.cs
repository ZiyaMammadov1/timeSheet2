using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddtinProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tin",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tin",
                table: "Positions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tin",
                table: "Departments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tin",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "tin",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "tin",
                table: "Departments");
        }
    }
}
