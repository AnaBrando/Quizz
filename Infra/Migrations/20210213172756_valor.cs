using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class valor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "Resposta",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Resposta");
        }
    }
}
