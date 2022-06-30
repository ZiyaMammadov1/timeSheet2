using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateFamilyMemberCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "FamilyMembers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_code",
                table: "FamilyMembers",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_code",
                table: "FamilyMembers");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
