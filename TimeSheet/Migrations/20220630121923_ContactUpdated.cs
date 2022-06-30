using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class ContactUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dbCode",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "fin",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "dbId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "employeeId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dbId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "employeeId",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "dbCode",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fin",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
