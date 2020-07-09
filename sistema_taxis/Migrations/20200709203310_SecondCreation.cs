using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_taxis.Migrations
{
    public partial class SecondCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Deuda",
                table: "Chofer",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deuda",
                table: "Chofer");
        }
    }
}
