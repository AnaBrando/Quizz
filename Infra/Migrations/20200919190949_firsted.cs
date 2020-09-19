using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class firsted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NivelId",
                table: "Pontuacao",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelId",
                table: "Pontuacao");
        }
    }
}
