using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class Migrations4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "databaseCode",
                table: "IdentityCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "databaseid",
                table: "IdentityCards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityCards_databaseid",
                table: "IdentityCards",
                column: "databaseid");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Database_databaseid",
                table: "IdentityCards",
                column: "databaseid",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Database_databaseid",
                table: "IdentityCards");

            migrationBuilder.DropIndex(
                name: "IX_IdentityCards_databaseid",
                table: "IdentityCards");

            migrationBuilder.DropColumn(
                name: "databaseCode",
                table: "IdentityCards");

            migrationBuilder.DropColumn(
                name: "databaseid",
                table: "IdentityCards");
        }
    }
}
