using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pontuacao",
                columns: table => new
                {
                    Pontuacao_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontuacao", x => x.Pontuacao_ID);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Professor_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Professor_ID);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    Nivel_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pontuacao_ID = table.Column<int>(nullable: false),
                    Pontuacao_ID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.Nivel_id);
                    table.ForeignKey(
                        name: "FK_Nivel_Pontuacao_Pontuacao_ID1",
                        column: x => x.Pontuacao_ID1,
                        principalTable: "Pontuacao",
                        principalColumn: "Pontuacao_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    Resposta_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespostaCerta = table.Column<string>(nullable: true),
                    Pergunta_id = table.Column<int>(nullable: false),
                    Estudante_ID = table.Column<int>(nullable: false),
                    Estudante_ID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.Resposta_id);
                });

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    Pergunta_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpcaoA = table.Column<string>(nullable: true),
                    OpcaoB = table.Column<string>(nullable: true),
                    OpcaoC = table.Column<string>(nullable: true),
                    OpcaoD = table.Column<string>(nullable: true),
                    OpcaoCerta = table.Column<string>(nullable: true),
                    Quizz_id = table.Column<int>(nullable: false),
                    Nivel_id = table.Column<int>(nullable: true),
                    QuizzQuiz_id = table.Column<int>(nullable: true),
                    Resposta_id = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
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
                    Turma_ID = table.Column<int>(nullable: false),
                    Professor_ID1 = table.Column<int>(nullable: true),
                    Professor_ID = table.Column<int>(nullable: false),
                    Turma_ID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizz", x => x.Quiz_id);
                    table.ForeignKey(
                        name: "FK_Quizz_Professor_Professor_ID1",
                        column: x => x.Professor_ID1,
                        principalTable: "Professor",
                        principalColumn: "Professor_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Turma_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizzQuiz_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Turma_ID);
                    table.ForeignKey(
                        name: "FK_Turma_Quizz_QuizzQuiz_id",
                        column: x => x.QuizzQuiz_id,
                        principalTable: "Quizz",
                        principalColumn: "Quiz_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estudante",
                columns: table => new
                {
                    Estudante_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Turma_ID = table.Column<int>(nullable: true),
                    Resposta_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudante", x => x.Estudante_ID);
                    table.ForeignKey(
                        name: "FK_Estudante_Resposta_Resposta_id",
                        column: x => x.Resposta_id,
                        principalTable: "Resposta",
                        principalColumn: "Resposta_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudante_Turma_Turma_ID",
                        column: x => x.Turma_ID,
                        principalTable: "Turma",
                        principalColumn: "Turma_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_Resposta_id",
                table: "Estudante",
                column: "Resposta_id");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_Turma_ID",
                table: "Estudante",
                column: "Turma_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_Pontuacao_ID1",
                table: "Nivel",
                column: "Pontuacao_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_Nivel_id",
                table: "Pergunta",
                column: "Nivel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_QuizzQuiz_id",
                table: "Pergunta",
                column: "QuizzQuiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_Quizz_Professor_ID1",
                table: "Quizz",
                column: "Professor_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Quizz_Turma_ID1",
                table: "Quizz",
                column: "Turma_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_Estudante_ID1",
                table: "Resposta",
                column: "Estudante_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_Pergunta_id",
                table: "Resposta",
                column: "Pergunta_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turma_QuizzQuiz_id",
                table: "Turma",
                column: "QuizzQuiz_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Estudante_Estudante_ID1",
                table: "Resposta",
                column: "Estudante_ID1",
                principalTable: "Estudante",
                principalColumn: "Estudante_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Pergunta_Pergunta_id",
                table: "Resposta",
                column: "Pergunta_id",
                principalTable: "Pergunta",
                principalColumn: "Pergunta_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pergunta_Quizz_QuizzQuiz_id",
                table: "Pergunta",
                column: "QuizzQuiz_id",
                principalTable: "Quizz",
                principalColumn: "Quiz_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizz_Turma_Turma_ID1",
                table: "Quizz",
                column: "Turma_ID1",
                principalTable: "Turma",
                principalColumn: "Turma_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudante_Resposta_Resposta_id",
                table: "Estudante");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizz_Turma_Turma_ID1",
                table: "Quizz");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Estudante");

            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "Pontuacao");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Quizz");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
