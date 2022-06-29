using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateIdentityCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Database_databaseid",
                table: "IdentityCards");

            migrationBuilder.DropColumn(
                name: "databaseCode",
                table: "IdentityCards");

            migrationBuilder.RenameColumn(
                name: "databaseid",
                table: "IdentityCards",
                newName: "databaseId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityCards_databaseid",
                table: "IdentityCards",
                newName: "IX_IdentityCards_databaseId");

            migrationBuilder.AlterColumn<int>(
                name: "databaseId",
                table: "IdentityCards",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Database_databaseId",
                table: "IdentityCards",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Database_databaseId",
                table: "IdentityCards");

            migrationBuilder.RenameColumn(
                name: "databaseId",
                table: "IdentityCards",
                newName: "databaseid");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityCards_databaseId",
                table: "IdentityCards",
                newName: "IX_IdentityCards_databaseid");

            migrationBuilder.AlterColumn<int>(
                name: "databaseid",
                table: "IdentityCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "databaseCode",
                table: "IdentityCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Database_databaseid",
                table: "IdentityCards",
                column: "databaseid",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
