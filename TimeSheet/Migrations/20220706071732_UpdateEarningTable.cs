using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateEarningTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "typeOfEarning",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "earning",
                table: "typeOfEarning",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "typeOfEarning");

            migrationBuilder.DropColumn(
                name: "earning",
                table: "typeOfEarning");
        }
    }
}
