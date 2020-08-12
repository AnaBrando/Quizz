using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudante_Turma_Turma_ID",
                table: "Estudante");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizz_Turma_Turma_ID1",
                table: "Quizz");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Quizz_Turma_ID1",
                table: "Quizz");

            migrationBuilder.DropIndex(
                name: "IX_Estudante_Turma_ID",
                table: "Estudante");

            migrationBuilder.DropColumn(
                name: "Turma_ID1",
                table: "Quizz");

            migrationBuilder.DropColumn(
                name: "Turma_ID",
                table: "Estudante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Turma_ID1",
                table: "Quizz",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Turma_ID",
                table: "Estudante",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Turma_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizzQuiz_id = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Quizz_Turma_ID1",
                table: "Quizz",
                column: "Turma_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_Turma_ID",
                table: "Estudante",
                column: "Turma_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_QuizzQuiz_id",
                table: "Turma",
                column: "QuizzQuiz_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudante_Turma_Turma_ID",
                table: "Estudante",
                column: "Turma_ID",
                principalTable: "Turma",
                principalColumn: "Turma_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizz_Turma_Turma_ID1",
                table: "Quizz",
                column: "Turma_ID1",
                principalTable: "Turma",
                principalColumn: "Turma_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
