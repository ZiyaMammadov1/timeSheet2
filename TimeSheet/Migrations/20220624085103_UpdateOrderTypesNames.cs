using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateOrderTypesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTypes",
                table: "OrderTypes",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTypes",
                table: "OrderTypes");

            migrationBuilder.RenameTable(
                name: "OrderTypes",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "id");
        }
    }
}
