using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddTypeOfOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "typeOfOrders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    code = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeOfOrders", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "typeOfOrders");
        }
    }
}
