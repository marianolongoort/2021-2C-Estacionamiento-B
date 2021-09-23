using Microsoft.EntityFrameworkCore.Migrations;

namespace EstacionamientoMVC.Migrations
{
    public partial class AddPersonaPasaporte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pasaporte",
                table: "Personas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pasaporte",
                table: "Personas");
        }
    }
}
