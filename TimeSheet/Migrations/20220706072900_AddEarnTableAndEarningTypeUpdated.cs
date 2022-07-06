using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddEarnTableAndEarningTypeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "typeOfEarning",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Earns",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    dbCode = table.Column<string>(nullable: true),
                    employeeId = table.Column<string>(nullable: true),
                    companyId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    earningTypeId = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earns", x => x.id);
                    table.ForeignKey(
                        name: "FK_Earns_typeOfEarning_earningTypeId",
                        column: x => x.earningTypeId,
                        principalTable: "typeOfEarning",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Earns_earningTypeId",
                table: "Earns",
                column: "earningTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Earns");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "typeOfEarning");
        }
    }
}
