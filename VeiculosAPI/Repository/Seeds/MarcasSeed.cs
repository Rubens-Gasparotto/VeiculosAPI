using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VeiculosAPI.Repository.Seeds
{
    public class MarcasSeed
    {
        public static void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "marcas",
                columns: new[] { "nome", "logo", "created_at", "updated_at" },
                values: new object[,] {
                    { "Chevrolet", "https://www.chevrolet.com.br/content/dam/chevrolet/na/us/english/primary-navigation-icons/chevrolet-logo-v2.png", DateTime.Now, DateTime.Now },
                    { "Ford", "https://www.ford.com.br/content/dam/Ford/website-assets/latam/br/home/fbr-home-opengraph-logo-ford.jpg", DateTime.Now, DateTime.Now },
                    { "Fiat", "https://www.fiat.com.br/content/dam/fiat/nova_home/logos/logo_header_hub_fiat.svg", DateTime.Now, DateTime.Now },
                    { "Honda", "https://www.honda.com.br/sites/cbw/themes/custom/honda/img/hondalogo.svg", DateTime.Now, DateTime.Now }
                }
            );
        }
    }
}
