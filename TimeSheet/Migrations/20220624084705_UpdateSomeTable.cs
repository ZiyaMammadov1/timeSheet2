using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateSomeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Salaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "IdentityCards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "IdentityCards");
        }
    }
}
