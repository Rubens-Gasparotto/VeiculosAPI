using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VeiculosAPI.Repository.Seeds
{
    public class PermissoesSeed
    {
        public static void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permissoes",
                columns: new[] { "nome", "tipo", "slug", "created_at", "updated_at" },
                values: new object[,] {
                    { "Usuários", "Criar", "criar:usuarios", DateTime.Now, DateTime.Now },
                    { "Usuários", "Editar", "editar:usuarios", DateTime.Now, DateTime.Now },
                    { "Usuários", "Listar", "listar:usuarios", DateTime.Now, DateTime.Now },
                    { "Usuários", "Visualizar", "visualizar:usuarios", DateTime.Now, DateTime.Now },
                    { "Usuários", "Remover", "remover:usuarios", DateTime.Now, DateTime.Now },

                    { "Marcas", "Criar", "criar:marcas", DateTime.Now, DateTime.Now },
                    { "Marcas", "Editar", "editar:marcas", DateTime.Now, DateTime.Now },
                    { "Marcas", "Listar", "listar:marcas", DateTime.Now, DateTime.Now },
                    { "Marcas", "Visualizar", "visualizar:marcas", DateTime.Now, DateTime.Now },
                    { "Marcas", "Remover", "remover:marcas", DateTime.Now, DateTime.Now },

                    { "Modelos", "Criar", "criar:modelos", DateTime.Now, DateTime.Now },
                    { "Modelos", "Editar", "editar:modelos", DateTime.Now, DateTime.Now },
                    { "Modelos", "Listar", "listar:modelos", DateTime.Now, DateTime.Now },
                    { "Modelos", "Visualizar", "visualizar:modelos", DateTime.Now, DateTime.Now },
                    { "Modelos", "Remover", "remover:modelos", DateTime.Now, DateTime.Now }
                }
            );
        }
    }
}
