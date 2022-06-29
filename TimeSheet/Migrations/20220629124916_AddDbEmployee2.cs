using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddDbEmployee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "positionId",
                table: "dBEmployees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_dBEmployees_positionId",
                table: "dBEmployees",
                column: "positionId");

            migrationBuilder.AddForeignKey(
                name: "FK_dBEmployees_Positions_positionId",
                table: "dBEmployees",
                column: "positionId",
                principalTable: "Positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dBEmployees_Positions_positionId",
                table: "dBEmployees");

            migrationBuilder.DropIndex(
                name: "IX_dBEmployees_positionId",
                table: "dBEmployees");

            migrationBuilder.DropColumn(
                name: "positionId",
                table: "dBEmployees");
        }
    }
}
