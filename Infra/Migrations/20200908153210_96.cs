using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _96 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Gabarito_GabaritoId",
                table: "Resposta");

            migrationBuilder.DropTable(
                name: "Gabarito");

            migrationBuilder.DropIndex(
                name: "IX_Resposta_GabaritoId",
                table: "Resposta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gabarito",
                columns: table => new
                {
                    GabaritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gabarito", x => x.GabaritoId);
                });

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
    }
}
