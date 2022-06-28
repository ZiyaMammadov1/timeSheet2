using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class Migrations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "port",
                table: "Database",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "server",
                table: "Database",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "port",
                table: "Database");

            migrationBuilder.DropColumn(
                name: "server",
                table: "Database");
        }
    }
}
