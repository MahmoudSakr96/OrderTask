using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlderTask.Infrastructure.Migrations
{
    public partial class ModifyOrderDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "OrderTask",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "OrderTask",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "OrderTask",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "OrderTask",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "OrderTask",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "OrderTask",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "OrderTask",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "OrderTask",
                table: "OrderDetails");
        }
    }
}
