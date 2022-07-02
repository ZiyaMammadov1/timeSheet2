using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddOrderRelationIntoDbEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Departments_Departmentid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Departmentid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Departmentid",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "dBEmployees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_deprtmentID",
                table: "Orders",
                column: "deprtmentID");

            migrationBuilder.CreateIndex(
                name: "IX_dBEmployees_orderId",
                table: "dBEmployees",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_dBEmployees_Orders_orderId",
                table: "dBEmployees",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Departments_deprtmentID",
                table: "Orders",
                column: "deprtmentID",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dBEmployees_Orders_orderId",
                table: "dBEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Departments_deprtmentID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_deprtmentID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_dBEmployees_orderId",
                table: "dBEmployees");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "dBEmployees");

            migrationBuilder.AddColumn<int>(
                name: "Departmentid",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Departmentid",
                table: "Orders",
                column: "Departmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Departments_Departmentid",
                table: "Orders",
                column: "Departmentid",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
