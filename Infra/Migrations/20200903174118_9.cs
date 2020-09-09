using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GabaritoId",
                table: "Resposta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_GabaritoId",
                table: "Resposta",
                column: "GabaritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Gabarito_GabaritoId",
                table: "Resposta",
                column: "GabaritoId",
                principalTable: "Gabarito",
                principalColumn: "GabaritoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Gabarito_GabaritoId",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Resposta_GabaritoId",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "GabaritoId",
                table: "Resposta");
        }
    }
}
