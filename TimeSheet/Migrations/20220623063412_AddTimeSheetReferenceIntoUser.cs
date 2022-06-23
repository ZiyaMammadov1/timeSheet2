using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddTimeSheetReferenceIntoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "MainTimeSheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MainTimeSheets_userId",
                table: "MainTimeSheets",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainTimeSheets_Users_userId",
                table: "MainTimeSheets",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainTimeSheets_Users_userId",
                table: "MainTimeSheets");

            migrationBuilder.DropIndex(
                name: "IX_MainTimeSheets_userId",
                table: "MainTimeSheets");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "MainTimeSheets");
        }
    }
}
