using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlderTask.Infrastructure.Migrations
{
    public partial class UpdateOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                schema: "OrderTask",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3776aa60-d17f-4a70-9b67-332020b00633", "DC21D266-C24A-4676-BDAE-345D0EE14766" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                schema: "OrderTask",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "762c08fb-04d9-4535-b974-9532f56c6d04", null });
        }
    }
}
