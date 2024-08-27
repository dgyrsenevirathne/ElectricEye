using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricEye.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatnew1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "EnergyUsages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "EnergyUsages");
        }
    }
}
