using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    code = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    name = table.Column<string>(nullable: true),
                    databaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Positions_Database_databaseId",
                        column: x => x.databaseId,
                        principalTable: "Database",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_databaseId",
                table: "Positions",
                column: "databaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
