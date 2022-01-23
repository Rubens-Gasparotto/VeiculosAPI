using Microsoft.EntityFrameworkCore.Migrations;
using VeiculosAPI.Repository.Seeds;

namespace VeiculosAPI.Migrations
{
    public partial class create_usuarios_permissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios_permissoes",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    permissao_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_permissoes", x => new { x.permissao_id, x.usuario_id });
                    table.ForeignKey(
                        name: "FK_usuarios_permissoes_permissoes_permissao_id",
                        column: x => x.permissao_id,
                        principalTable: "permissoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_permissoes_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_permissoes_usuario_id",
                table: "usuarios_permissoes",
                column: "usuario_id");

            UsuarioPermissaoSeed.Seed(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios_permissoes");
        }
    }
}
