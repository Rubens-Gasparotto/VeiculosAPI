using Microsoft.EntityFrameworkCore.Migrations;

namespace VeiculosAPI.Repository.Seeds
{
    public class UsuarioPermissaoSeed
    {
        public static void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "usuarios_permissoes",
                columns: new[] { "usuario_id", "permissao_id" },
                values: new object[,] {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 }
                }
            );
        }
    }
}
