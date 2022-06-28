using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adress",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "dbCode",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "expireDate",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "isActive",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "issiedBy",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "phone1",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone2",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone3",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone4",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "photo",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "seriya",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "dbCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "expireDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "issiedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "number",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "phone1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "phone2",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "phone3",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "phone4",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "photo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "seriya",
                table: "Employees");
        }
    }
}
