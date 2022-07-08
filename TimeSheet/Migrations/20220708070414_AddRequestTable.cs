using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<int>(nullable: false),
                    companyId = table.Column<int>(nullable: false),
                    databaseId = table.Column<int>(nullable: false),
                    requestTypeId = table.Column<int>(nullable: false),
                    statusId = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    dateTo = table.Column<DateTime>(nullable: false),
                    dateFrom = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_Requests_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Database_databaseId",
                        column: x => x.databaseId,
                        principalTable: "Database",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_RequestTypes_requestTypeId",
                        column: x => x.requestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Statuses_statusId",
                        column: x => x.statusId,
                        principalTable: "Statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_companyId",
                table: "Requests",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_databaseId",
                table: "Requests",
                column: "databaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_employeeId",
                table: "Requests",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_requestTypeId",
                table: "Requests",
                column: "requestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_statusId",
                table: "Requests",
                column: "statusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
