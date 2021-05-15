using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initial : Migration
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
                    Nome = table.Column<string>(nullable: true),
                    Pontuacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudante", x => x.EstudanteId);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorSessao = table.Column<string>(nullable: true),
                    QuizzId = table.Column<int>(nullable: false)
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
                    ProfessorSessao = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false)
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
                    Acertou = table.Column<bool>(nullable: false),
                    EstudanteChave = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    EstudanteId = table.Column<int>(nullable: false),
                    PerguntaId = table.Column<int>(nullable: false),
                    Valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.RespostaId);
                });

            migrationBuilder.CreateTable(
                name: "EstudanteResposta",
                columns: table => new
                {
                    EstudanteId = table.Column<int>(nullable: false),
                    RespostaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudanteResposta", x => new { x.EstudanteId, x.RespostaId });
                    table.ForeignKey(
                        name: "FK_EstudanteResposta_Estudante_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Estudante",
                        principalColumn: "EstudanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudanteResposta_Resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalTable: "Resposta",
                        principalColumn: "RespostaId",
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
                    OpcaoA = table.Column<string>(nullable: false),
                    OpcaoB = table.Column<string>(nullable: false),
                    OpcaoC = table.Column<string>(nullable: false),
                    OpcaoD = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    OpcaoCerta = table.Column<string>(nullable: false),
                    EstudanteRespostaEstudanteId = table.Column<int>(nullable: true),
                    EstudanteRespostaRespostaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.PerguntaId);
                    table.ForeignKey(
                        name: "FK_Pergunta_Quizz_QuizzId",
                        column: x => x.QuizzId,
                        principalTable: "Quizz",
                        principalColumn: "QuizzId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pergunta_Resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalTable: "Resposta",
                        principalColumn: "RespostaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pergunta_EstudanteResposta_EstudanteRespostaEstudanteId_EstudanteRespostaRespostaId",
                        columns: x => new { x.EstudanteRespostaEstudanteId, x.EstudanteRespostaRespostaId },
                        principalTable: "EstudanteResposta",
                        principalColumns: new[] { "EstudanteId", "RespostaId" },
                        onDelete: ReferentialAction.Restrict);
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
                name: "Nivel",
                columns: table => new
                {
                    NivelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    PontuacaoId = table.Column<int>(nullable: false),
                    PontuacaoId2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.NivelId);
                    table.ForeignKey(
                        name: "FK_Nivel_Pontuacao_PontuacaoId2",
                        column: x => x.PontuacaoId2,
                        principalTable: "Pontuacao",
                        principalColumn: "PontuacaoId",
                        onDelete: ReferentialAction.Restrict);
                });
                migrationBuilder.InsertData(
                                        table: "Nivel",
                                        columns: new[] { "NivelId", "Descricao", "PontuacaoId"},
                                        values: new object[] { "1", "Difícil", "1"
                                        ,"ABDC",true,DateTime.Now,1});
                migrationBuilder.InsertData(
                                        table: "Nivel",
                                        columns: new[] { "NivelId", "Descricao", "PontuacaoId"},
                                        values: new object[] { "2", "Moderado", "2"
                                        ,"ABDC",true,DateTime.Now,1});
                migrationBuilder.InsertData(
                                        table: "Nivel",
                                        columns: new[] { "NivelId", "Descricao", "PontuacaoId"},
                                        values: new object[] { "3", "Facil", "3"
                                        ,"ABDC",true,DateTime.Now,1});
                                        
                migrationBuilder.InsertData(
                                        table: "Pontuacao",
                                        columns: new[] { "PontuacaoId", "Valor", "NivelId"},
                                        values: new object[] { "1", 100, "1"
                                        ,"ABDC",true,DateTime.Now,1});
                                        migrationBuilder.InsertData(
                                        table: "Pontuacao",
                                        columns: new[] { "PontuacaoId", "Valor", "NivelId"},
                                        values: new object[] { "2", 50, "2"
                                        ,"ABDC",true,DateTime.Now,1});
                                        migrationBuilder.InsertData(
                                        table: "Pontuacao",
                                        columns: new[] { "PontuacaoId", "Valor", "NivelId"},
                                        values: new object[] { "3", 25, "3"
                                        ,"ABDC",true,DateTime.Now,1});
            migrationBuilder.CreateIndex(
                name: "IX_EstudanteResposta_RespostaId",
                table: "EstudanteResposta",
                column: "RespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_PontuacaoId2",
                table: "Nivel",
                column: "PontuacaoId2");

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
                name: "IX_Pergunta_EstudanteRespostaEstudanteId_EstudanteRespostaRespostaId",
                table: "Pergunta",
                columns: new[] { "EstudanteRespostaEstudanteId", "EstudanteRespostaRespostaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Pontuacao_NivelId",
                table: "Pontuacao",
                column: "NivelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pergunta_Nivel_NivelId",
                table: "Pergunta",
                column: "NivelId",
                principalTable: "Nivel",
                principalColumn: "NivelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pontuacao_Nivel_NivelId",
                table: "Pontuacao",
                column: "NivelId",
                principalTable: "Nivel",
                principalColumn: "NivelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nivel_Pontuacao_PontuacaoId2",
                table: "Nivel");

            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Quizz");

            migrationBuilder.DropTable(
                name: "EstudanteResposta");

            migrationBuilder.DropTable(
                name: "Estudante");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Pontuacao");

            migrationBuilder.DropTable(
                name: "Nivel");
        }
    }
}
