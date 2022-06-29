using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddOrderTable : Migration
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
                name: "FK_IdentityCards_Database_databaseId",
                table: "IdentityCards");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Employees_employeeId",
                table: "IdentityCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Database_databaseId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Database_databaseId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Employees_employeeId",
                table: "RefreshTokens");

            migrationBuilder.AddColumn<int>(
                name: "Databaseid",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Databaseid",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    dbCode = table.Column<string>(nullable: true),
                    fin = table.Column<string>(nullable: true),
                    tin = table.Column<string>(nullable: true),
                    orderType = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    dateEffective = table.Column<DateTime>(nullable: false),
                    dateExpired = table.Column<DateTime>(nullable: false),
                    dateTo = table.Column<DateTime>(nullable: false),
                    salary1 = table.Column<int>(nullable: false),
                    salary2 = table.Column<int>(nullable: false),
                    dalaryTotal = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    projectId = table.Column<int>(nullable: false),
                    deprtmentID = table.Column<int>(nullable: false),
                    Departmentid = table.Column<int>(nullable: true),
                    positionId = table.Column<int>(nullable: false),
                    companyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Departments_Departmentid",
                        column: x => x.Departmentid,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Projects_projectId",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Databaseid",
                table: "Employees",
                column: "Databaseid");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Databaseid",
                table: "Contacts",
                column: "Databaseid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Departmentid",
                table: "Orders",
                column: "Departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_companyId",
                table: "Orders",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_positionId",
                table: "Orders",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_projectId",
                table: "Orders",
                column: "projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Database_databaseId",
                table: "Companies",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Database_Databaseid",
                table: "Contacts",
                column: "Databaseid",
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
                name: "FK_Employees_Database_Databaseid",
                table: "Employees",
                column: "Databaseid",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Database_databaseId",
                table: "IdentityCards",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Employees_employeeId",
                table: "IdentityCards",
                column: "employeeId",
                principalTable: "Employees",
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
                name: "FK_Contacts_Database_Databaseid",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Database_databaseId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Database_Databaseid",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Database_databaseId",
                table: "IdentityCards");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Employees_employeeId",
                table: "IdentityCards");

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
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Databaseid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Databaseid",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Databaseid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Databaseid",
                table: "Contacts");

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
                name: "FK_IdentityCards_Database_databaseId",
                table: "IdentityCards",
                column: "databaseId",
                principalTable: "Database",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Employees_employeeId",
                table: "IdentityCards",
                column: "employeeId",
                principalTable: "Employees",
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
