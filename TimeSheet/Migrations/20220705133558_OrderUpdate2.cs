using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class OrderUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderType",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "typeOfOrderId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_typeOfOrderId",
                table: "Orders",
                column: "typeOfOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_typeOfOrders_typeOfOrderId",
                table: "Orders",
                column: "typeOfOrderId",
                principalTable: "typeOfOrders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_typeOfOrders_typeOfOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_typeOfOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "typeOfOrderId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "orderType",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
