using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcosystemSmartHome.Migrations
{
    public partial class addTwoField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "luminosity",
                table: "room_info",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "pressure",
                table: "room_info",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "luminosity",
                table: "room_info");

            migrationBuilder.DropColumn(
                name: "pressure",
                table: "room_info");
        }
    }
}
