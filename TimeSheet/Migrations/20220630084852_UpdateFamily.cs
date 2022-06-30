using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dbCode",
                table: "FamilyMembers");

            migrationBuilder.AddColumn<string>(
                name: "dbId",
                table: "FamilyMembers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dbId",
                table: "FamilyMembers");

            migrationBuilder.AddColumn<string>(
                name: "dbCode",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
