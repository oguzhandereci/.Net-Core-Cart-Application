using Microsoft.EntityFrameworkCore.Migrations;

namespace DNB.Supermarket.DataAccess.Migrations.My
{
    public partial class a4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellingQuantity",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellingQuantity",
                table: "OrderProducts");
        }
    }
}
