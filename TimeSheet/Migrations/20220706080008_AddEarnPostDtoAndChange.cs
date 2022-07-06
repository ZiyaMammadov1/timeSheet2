using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddEarnPostDtoAndChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "employeeId",
                table: "Earns",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "companyId",
                table: "Earns",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "Earns",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Earns_companyId",
                table: "Earns",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Earns_employeeId",
                table: "Earns",
                column: "employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Earns_Companies_companyId",
                table: "Earns",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Earns_Employees_employeeId",
                table: "Earns",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Earns_Companies_companyId",
                table: "Earns");

            migrationBuilder.DropForeignKey(
                name: "FK_Earns_Employees_employeeId",
                table: "Earns");

            migrationBuilder.DropIndex(
                name: "IX_Earns_companyId",
                table: "Earns");

            migrationBuilder.DropIndex(
                name: "IX_Earns_employeeId",
                table: "Earns");

            migrationBuilder.DropColumn(
                name: "code",
                table: "Earns");

            migrationBuilder.AlterColumn<string>(
                name: "employeeId",
                table: "Earns",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "companyId",
                table: "Earns",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
