using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuppaComfort.Migrations
{
    public partial class PositionRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Pay",
                table: "Positions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Prerequisites",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Pay",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Prerequisites",
                table: "Positions");
        }
    }
}
