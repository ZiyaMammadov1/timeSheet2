using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddDbEmployeeAndClearForeignKeysCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Database_databaseId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Database_databaseId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Database_databaseId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Database_databaseId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Employees_employeeId",
                table: "RefreshTokens");

            migrationBuilder.CreateTable(
                name: "DbEmployees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    code = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    isActive = table.Column<bool>(nullable: false, defaultValue: true),
                    employeeId = table.Column<int>(nullable: false),
                    databaseId = table.Column<int>(nullable: false),
                    companyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEmployees", x => x.id);
                    table.ForeignKey(
                        name: "FK_DbEmployees_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbEmployees_Database_databaseId",
                        column: x => x.databaseId,
                        principalTable: "Database",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbEmployees_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbEmployees_companyId",
                table: "DbEmployees",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_DbEmployees_databaseId",
                table: "DbEmployees",
                column: "databaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DbEmployees_employeeId",
                table: "DbEmployees",
                column: "employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Database_databaseId",
                table: "Companies",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Database_databaseId",
                table: "Departments",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Database_databaseId",
                table: "Positions",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Database_databaseId",
                table: "Projects",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Employees_employeeId",
                table: "RefreshTokens",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Database_databaseId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Database_databaseId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Database_databaseId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Database_databaseId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Employees_employeeId",
                table: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "DbEmployees");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Database_databaseId",
                table: "Companies",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Database_databaseId",
                table: "Departments",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Database_databaseId",
                table: "Positions",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Database_databaseId",
                table: "Projects",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Employees_employeeId",
                table: "RefreshTokens",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
