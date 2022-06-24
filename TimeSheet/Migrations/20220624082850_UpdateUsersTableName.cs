using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateUsersTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Users_userId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Users_userId",
                table: "IdentityCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MainTimeSheets_Users_userId",
                table: "MainTimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_Userid",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Users_userId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_departmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_positionId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Users_positionId",
                table: "Employees",
                newName: "IX_Employees_positionId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_fin",
                table: "Employees",
                newName: "IX_Employees_fin");

            migrationBuilder.RenameIndex(
                name: "IX_Users_departmentId",
                table: "Employees",
                newName: "IX_Employees_departmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_RefreshTokens_Employees_Userid",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_userId",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_positionId",
                table: "Users",
                newName: "IX_Users_positionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_fin",
                table: "Users",
                newName: "IX_Users_fin");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_departmentId",
                table: "Users",
                newName: "IX_Users_departmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Users_userId",
                table: "FamilyMembers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Users_userId",
                table: "IdentityCards",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainTimeSheets_Users_userId",
                table: "MainTimeSheets",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_Userid",
                table: "RefreshTokens",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Users_userId",
                table: "Salaries",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_departmentId",
                table: "Users",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_positionId",
                table: "Users",
                column: "positionId",
                principalTable: "Positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
