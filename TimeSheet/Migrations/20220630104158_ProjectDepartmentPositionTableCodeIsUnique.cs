using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class ProjectDepartmentPositionTableCodeIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Positions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_code",
                table: "Projects",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_code",
                table: "Positions",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_code",
                table: "Departments",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_code",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Positions_code",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Departments_code",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
