using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddAllTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Database",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    code = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Database", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    code = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    fin = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

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
                    isActive = table.Column<bool>(nullable: false, defaultValue: true),
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

            migrationBuilder.CreateTable(
                name: "Departments",
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
                    table.PrimaryKey("PK_Departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departments_Database_databaseId",
                        column: x => x.databaseId,
                        principalTable: "Database",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Projects",
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
                    table.PrimaryKey("PK_Projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Projects_Database_databaseId",
                        column: x => x.databaseId,
                        principalTable: "Database",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<int>(nullable: false),
                    RefreshTokenString = table.Column<string>(nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_databaseId",
                table: "Companies",
                column: "databaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_databaseId",
                table: "Departments",
                column: "databaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_fin",
                table: "Employees",
                column: "fin",
                unique: true,
                filter: "[fin] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_databaseId",
                table: "Positions",
                column: "databaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_databaseId",
                table: "Projects",
                column: "databaseId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_employeeId",
                table: "RefreshTokens",
                column: "employeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "typeOfOrders");

            migrationBuilder.DropTable(
                name: "Database");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
