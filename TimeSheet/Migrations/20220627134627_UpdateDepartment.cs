using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Database_Databaseid",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "dbId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Databaseid",
                table: "Departments",
                newName: "databaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_Databaseid",
                table: "Departments",
                newName: "IX_Departments_databaseId");

            migrationBuilder.AlterColumn<int>(
                name: "databaseId",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Database_databaseId",
                table: "Departments",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Database_databaseId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "databaseId",
                table: "Departments",
                newName: "Databaseid");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_databaseId",
                table: "Departments",
                newName: "IX_Departments_Databaseid");

            migrationBuilder.AlterColumn<int>(
                name: "Databaseid",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "dbId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Database_Databaseid",
                table: "Departments",
                column: "Databaseid",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
