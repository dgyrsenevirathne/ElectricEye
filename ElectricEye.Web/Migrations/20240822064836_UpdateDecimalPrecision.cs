using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricEye.Web.Migrations
{
    public partial class UpdateDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Consumption",
                table: "EnergyUsages",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // If you want to revert to the previous column type, specify the previous type here
            migrationBuilder.AlterColumn<decimal>(
                name: "Consumption",
                table: "EnergyUsages",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
