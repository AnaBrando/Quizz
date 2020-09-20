using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Estudante_EstudanteId1",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Resposta_EstudanteId1",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "EstudanteId1",
                table: "Resposta");

            migrationBuilder.AlterColumn<int>(
                name: "EstudanteId",
                table: "Resposta",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstudanteChave",
                table: "Resposta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_EstudanteId",
                table: "Resposta",
                column: "EstudanteId");

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

            migrationBuilder.DropIndex(
                name: "IX_Resposta_EstudanteId",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "EstudanteChave",
                table: "Resposta");

            migrationBuilder.AlterColumn<string>(
                name: "EstudanteId",
                table: "Resposta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstudanteId1",
                table: "Resposta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_EstudanteId1",
                table: "Resposta",
                column: "EstudanteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Estudante_EstudanteId1",
                table: "Resposta",
                column: "EstudanteId1",
                principalTable: "Estudante",
                principalColumn: "EstudanteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
