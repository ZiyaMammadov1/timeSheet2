using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddReferenceDepartmentCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_companyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_positionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Employees_userId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Employees_userId",
                table: "IdentityCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MainTimeSheets_Employees_userId",
                table: "MainTimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_companyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Employees_Userid",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_userId",
                table: "Salaries");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Departments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                table: "Departments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_companyId",
                table: "Employees",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departmentId",
                table: "Employees",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_positionId",
                table: "Employees",
                column: "positionId",
                principalTable: "Positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Employees_userId",
                table: "FamilyMembers",
                column: "userId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Employees_userId",
                table: "IdentityCards",
                column: "userId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainTimeSheets_Employees_userId",
                table: "MainTimeSheets",
                column: "userId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_companyId",
                table: "Projects",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Employees_Userid",
                table: "RefreshTokens",
                column: "Userid",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_userId",
                table: "Salaries",
                column: "userId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_companyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_positionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Employees_userId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Employees_userId",
                table: "IdentityCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MainTimeSheets_Employees_userId",
                table: "MainTimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_companyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Employees_Userid",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_userId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Departments");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_companyId",
                table: "Employees",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departmentId",
                table: "Employees",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_positionId",
                table: "Employees",
                column: "positionId",
                principalTable: "Positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Employees_userId",
                table: "FamilyMembers",
                column: "userId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Employees_userId",
                table: "IdentityCards",
                column: "userId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainTimeSheets_Employees_userId",
                table: "MainTimeSheets",
                column: "userId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_companyId",
                table: "Projects",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Employees_Userid",
                table: "RefreshTokens",
                column: "Userid",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_userId",
                table: "Salaries",
                column: "userId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
