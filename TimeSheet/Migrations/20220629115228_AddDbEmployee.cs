using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddDbEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dBEmployees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<int>(nullable: false),
                    databaseId = table.Column<int>(nullable: false),
                    companyId = table.Column<int>(nullable: false),
                    departmentId = table.Column<int>(nullable: false),
                    projectId = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false, defaultValue: true),
                    isDelete = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dBEmployees", x => x.id);
                    table.ForeignKey(
                        name: "FK_dBEmployees_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dBEmployees_Database_databaseId",
                        column: x => x.databaseId,
                        principalTable: "Database",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dBEmployees_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dBEmployees_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dBEmployees_Projects_projectId",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dBEmployees_companyId",
                table: "dBEmployees",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_dBEmployees_databaseId",
                table: "dBEmployees",
                column: "databaseId");

            migrationBuilder.CreateIndex(
                name: "IX_dBEmployees_departmentId",
                table: "dBEmployees",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_dBEmployees_employeeId",
                table: "dBEmployees",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_dBEmployees_projectId",
                table: "dBEmployees",
                column: "projectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dBEmployees");
        }
    }
}
