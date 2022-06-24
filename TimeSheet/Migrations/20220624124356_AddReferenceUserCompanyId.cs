using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddReferenceUserCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "companyId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_companyId",
                table: "Employees",
                column: "companyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_companyId",
                table: "Employees",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_companyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_companyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "companyId",
                table: "Employees");
        }
    }
}
