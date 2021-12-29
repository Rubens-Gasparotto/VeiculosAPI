using Microsoft.EntityFrameworkCore.Migrations;
using System;
using VeiculosAPI.Core.Passwords;

namespace VeiculosAPI.Repository.Seeds
{
    public static class UsuariosSeed
    {
        public static void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "nome", "email", "senha", "email_verificado_em", "created_at", "updated_at" },
                values: new object[,] {
                    { "Administrador geral", "admin@veiculos.com.br", PasswordHasher.Hash("admin@veiculos"), DateTime.Now, DateTime.Now, DateTime.Now }
                }
            );
        }
    }
}
