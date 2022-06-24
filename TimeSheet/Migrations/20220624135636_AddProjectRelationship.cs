using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddProjectRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "projectId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_projectId",
                table: "Employees",
                column: "projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_projectId",
                table: "Employees",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_projectId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_projectId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "projectId",
                table: "Employees");
        }
    }
}
