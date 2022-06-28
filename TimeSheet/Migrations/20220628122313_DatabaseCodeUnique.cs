using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class DatabaseCodeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Database",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    code = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    employeeId = table.Column<int>(nullable: false),
                    companyId = table.Column<int>(nullable: false),
                    databaseId = table.Column<int>(nullable: false),
                    projectId = table.Column<int>(nullable: false),
                    departmentId = table.Column<int>(nullable: false),
                    salary1 = table.Column<string>(nullable: true),
                    salary2 = table.Column<string>(nullable: true),
                    salaryTotal = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    expiryDate = table.Column<DateTime>(nullable: false),
                    dateFrom = table.Column<DateTime>(nullable: false),
                    dateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Database_databaseId",
                        column: x => x.databaseId,
                        principalTable: "Database",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
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
                name: "IX_Database_code",
                table: "Database",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_companyId",
                table: "Orders",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_databaseId",
                table: "Orders",
                column: "databaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_departmentId",
                table: "Orders",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_employeeId",
                table: "Orders",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_projectId",
                table: "Orders",
                column: "projectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Database_code",
                table: "Database");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Database",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
