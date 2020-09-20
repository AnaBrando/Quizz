using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudante",
                columns: table => new
                {
                    EstudanteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudanteSessao = table.Column<string>(nullable: true),
                    Pontuacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudante", x => x.EstudanteId);
                });

            migrationBuilder.CreateTable(
                name: "Pontuacao",
                columns: table => new
                {
                    PontuacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(nullable: false),
                    NivelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontuacao", x => x.PontuacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorSessao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "Quizz",
                columns: table => new
                {
                    QuizzId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    ProfessorSessao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizz", x => x.QuizzId);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    RespostaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudanteId = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    EstudanteId1 = table.Column<int>(nullable: true),
                    PerguntaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.RespostaId);
                    table.ForeignKey(
                        name: "FK_Resposta_Estudante_EstudanteId1",
                        column: x => x.EstudanteId1,
                        principalTable: "Estudante",
                        principalColumn: "EstudanteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    NivelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    PontuacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.NivelId);
                    table.ForeignKey(
                        name: "FK_Nivel_Pontuacao",
                        column: x => x.PontuacaoId,
                        principalTable: "Pontuacao",
                        principalColumn: "PontuacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    PerguntaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelId = table.Column<int>(nullable: true),
                    RespostaId = table.Column<int>(nullable: true),
                    QuizzId = table.Column<int>(nullable: false),
                    OpcaoA = table.Column<string>(nullable: true),
                    OpcaoB = table.Column<string>(nullable: true),
                    OpcaoC = table.Column<string>(nullable: true),
                    OpcaoD = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    OpcaoCerta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.PerguntaId);
                    table.ForeignKey(
                        name: "FK_Pergunta_Nivel",
                        column: x => x.NivelId,
                        principalTable: "Nivel",
                        principalColumn: "NivelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pergunta_Quizz",
                        column: x => x.QuizzId,
                        principalTable: "Quizz",
                        principalColumn: "QuizzId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pergunta_Resposta",
                        column: x => x.RespostaId,
                        principalTable: "Resposta",
                        principalColumn: "RespostaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_PontuacaoId",
                table: "Nivel",
                column: "PontuacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_NivelId",
                table: "Pergunta",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_QuizzId",
                table: "Pergunta",
                column: "QuizzId");

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_RespostaId",
                table: "Pergunta",
                column: "RespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_EstudanteId1",
                table: "Resposta",
                column: "EstudanteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "Quizz");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Pontuacao");

            migrationBuilder.DropTable(
                name: "Estudante");
        }
    }
}
