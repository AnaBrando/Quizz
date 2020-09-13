using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _523 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Estudante",
                table: "Resposta");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Estudante_EstudanteId",
                table: "Resposta",
                column: "EstudanteId",
                principalTable: "Estudante",
                principalColumn: "EstudanteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Estudante_EstudanteId",
                table: "Resposta");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Estudante",
                table: "Resposta",
                column: "EstudanteId",
                principalTable: "Estudante",
                principalColumn: "EstudanteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
