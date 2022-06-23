using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddPhonesNumberIntoUserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phone1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone2",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone3",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone4",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "phone2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "phone3",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "phone4",
                table: "Users");
        }
    }
}
