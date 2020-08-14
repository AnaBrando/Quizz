using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _63 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nivel_Pontuacao_Pontuacao_ID1",
                table: "Nivel");

            migrationBuilder.DropIndex(
                name: "IX_Nivel_Pontuacao_ID1",
                table: "Nivel");

            migrationBuilder.DropColumn(
                name: "Pontuacao_ID1",
                table: "Nivel");

            migrationBuilder.AlterColumn<int>(
                name: "Pontuacao_ID",
                table: "Nivel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_Pontuacao_ID",
                table: "Nivel",
                column: "Pontuacao_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nivel_Pontuacao_Pontuacao_ID",
                table: "Nivel",
                column: "Pontuacao_ID",
                principalTable: "Pontuacao",
                principalColumn: "Pontuacao_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nivel_Pontuacao_Pontuacao_ID",
                table: "Nivel");

            migrationBuilder.DropIndex(
                name: "IX_Nivel_Pontuacao_ID",
                table: "Nivel");

            migrationBuilder.AlterColumn<int>(
                name: "Pontuacao_ID",
                table: "Nivel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pontuacao_ID1",
                table: "Nivel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_Pontuacao_ID1",
                table: "Nivel",
                column: "Pontuacao_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Nivel_Pontuacao_Pontuacao_ID1",
                table: "Nivel",
                column: "Pontuacao_ID1",
                principalTable: "Pontuacao",
                principalColumn: "Pontuacao_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
