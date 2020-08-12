using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _963 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turma_ID",
                table: "Quizz");

            migrationBuilder.AlterColumn<string>(
                name: "Professor_ID",
                table: "Quizz",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Professor_ID",
                table: "Quizz",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Turma_ID",
                table: "Quizz",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
