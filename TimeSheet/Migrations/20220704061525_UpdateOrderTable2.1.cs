using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateOrderTable21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateFrom",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "days",
                table: "Orders",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "place",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "totalDays",
                table: "Orders",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateFrom",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "days",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "place",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "totalDays",
                table: "Orders");
        }
    }
}
