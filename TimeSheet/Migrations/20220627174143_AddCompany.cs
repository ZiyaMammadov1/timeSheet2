using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    code = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    tin = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    databaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Companies_Database_databaseId",
                        column: x => x.databaseId,
                        principalTable: "Database",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_databaseId",
                table: "Companies",
                column: "databaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
