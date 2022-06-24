using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class RelationsProjectAndCompanyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "companyId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_companyId",
                table: "Projects",
                column: "companyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_companyId",
                table: "Projects",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_companyId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_companyId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "companyId",
                table: "Projects");
        }
    }
}
