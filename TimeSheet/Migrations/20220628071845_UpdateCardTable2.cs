using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateCardTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Employees_employeeId",
                table: "Card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "IdentityCards");

            migrationBuilder.RenameIndex(
                name: "IX_Card_employeeId",
                table: "IdentityCards",
                newName: "IX_IdentityCards_employeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityCards",
                table: "IdentityCards",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Employees_employeeId",
                table: "IdentityCards",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Employees_employeeId",
                table: "IdentityCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityCards",
                table: "IdentityCards");

            migrationBuilder.RenameTable(
                name: "IdentityCards",
                newName: "Card");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityCards_employeeId",
                table: "Card",
                newName: "IX_Card_employeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Employees_employeeId",
                table: "Card",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
