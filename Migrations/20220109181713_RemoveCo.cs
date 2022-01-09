using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcosystemSmartHome.Migrations
{
    public partial class RemoveCo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity_co",
                table: "room_info");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "quantity_co",
                table: "room_info",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
