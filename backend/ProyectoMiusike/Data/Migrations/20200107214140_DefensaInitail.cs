using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoMiusike.Data.Migrations
{
    public partial class DefensaInitail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ventas",
                table: "Caciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Votacion",
                table: "Caciones",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ventas",
                table: "Caciones");

            migrationBuilder.DropColumn(
                name: "Votacion",
                table: "Caciones");
        }
    }
}
