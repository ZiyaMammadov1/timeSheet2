using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateFamliesTablePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "memberAge",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "memberDoB",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "memberFullName",
                table: "FamilyMembers");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "FamilyMembers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "FamilyMembers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "FamilyMembers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "dob",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "fullName",
                table: "FamilyMembers");

            migrationBuilder.AddColumn<int>(
                name: "memberAge",
                table: "FamilyMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "memberDoB",
                table: "FamilyMembers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "memberFullName",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
