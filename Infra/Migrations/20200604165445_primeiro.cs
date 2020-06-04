using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class primeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Categoria_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Categoria_id);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    Nivel_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Pontuacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.Nivel_id);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    Resposta_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespostaCerta = table.Column<string>(nullable: true),
                    Pergunta_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.Resposta_id);
                });

            migrationBuilder.CreateTable(
                name: "Quizz",
                columns: table => new
                {
                    Quiz_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusão = table.Column<DateTime>(nullable: false),
                    Categoria_id1 = table.Column<int>(nullable: true),
                    Categoria_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizz", x => x.Quiz_id);
                    table.ForeignKey(
                        name: "FK_Quizz_Categorias_Categoria_id1",
                        column: x => x.Categoria_id1,
                        principalTable: "Categorias",
                        principalColumn: "Categoria_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    Pergunta_id = table.Column<int>(nullable: false),
                    OpcaoA = table.Column<string>(nullable: true),
                    OpcaoB = table.Column<string>(nullable: true),
                    OpcaoC = table.Column<string>(nullable: true),
                    OpcaoD = table.Column<string>(nullable: true),
                    OpcaoCerta = table.Column<string>(nullable: true),
                    Quizz_id = table.Column<int>(nullable: false),
                    QuizzQuiz_id = table.Column<int>(nullable: true),
                    Resposta_id = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Nivel_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.Pergunta_id);
                    table.ForeignKey(
                        name: "FK_Pergunta_Nivel_Nivel_id",
                        column: x => x.Nivel_id,
                        principalTable: "Nivel",
                        principalColumn: "Nivel_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pergunta_Resposta_Pergunta_id",
                        column: x => x.Pergunta_id,
                        principalTable: "Resposta",
                        principalColumn: "Resposta_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pergunta_Quizz_QuizzQuiz_id",
                        column: x => x.QuizzQuiz_id,
                        principalTable: "Quizz",
                        principalColumn: "Quiz_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_Nivel_id",
                table: "Pergunta",
                column: "Nivel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_QuizzQuiz_id",
                table: "Pergunta",
                column: "QuizzQuiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_Quizz_Categoria_id1",
                table: "Quizz",
                column: "Categoria_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Quizz");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
