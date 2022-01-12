using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VeiculosAPI.Repository.Seeds
{
    public class ModelosSeed
    {
        public static void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "modelos",
                columns: new[] { "nome", "inicio_fabricacao", "fim_fabricacao", "imagem", "marca_id", "created_at", "updated_at" },
                values: new object[,] {
                    { "Celta", 2000, 2015, "https://conteudo.imguol.com.br/c/entretenimento/65/2018/01/25/chevroelt-celta-2012-1516889393894_v2_450x337.jpg", 1, DateTime.Now, DateTime.Now },
                    { "Corsa", 1994, 2015, "http://1.bp.blogspot.com/-xxJ-xpLNTQc/TvcDaHvaHJI/AAAAAAAAVw4/MHhN_zcJKK4/s640/corsaenergy.jpg", 1, DateTime.Now, DateTime.Now },
                    { "Ka", 1996, null, "https://quatrorodas.abril.com.br/wp-content/uploads/2018/02/ford-ka_plus-2019-1600-06.jpg", 2, DateTime.Now, DateTime.Now },
                    { "Fiesta", 1976, null, "https://i0.statig.com.br/bancodeimagens/ak/s3/qk/aks3qkbo0qnkh2u97rtv0jkin.jpg", 2, DateTime.Now, DateTime.Now },
                    { "Uno", 1984, 2021, "https://cdn.motor1.com/images/mgl/Vo13B/s1/4x3/fiat-uno-attractive.webp", 3, DateTime.Now, DateTime.Now },
                    { "Palio", 1996, 2018, "https://www.autoo.com.br/fotos/2016/3/960_720/Pfire_22032016_1777_960_720.jpg", 3, DateTime.Now, DateTime.Now },
                    { "Fit", 2001, null, "https://quatrorodas.abril.com.br/wp-content/uploads/2021/11/qr-700-car-h-fit-32-e1636758826476.jpg?quality=70&strip=info", 4, DateTime.Now, DateTime.Now },
                    { "Civic", 1972, null, "https://quatrorodas.abril.com.br/wp-content/uploads/2021/12/DSCF0337.jpg?quality=70&strip=info", 4, DateTime.Now, DateTime.Now }
                }
            );
        }
    }
}
