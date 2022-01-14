using Microsoft.Extensions.Configuration;
using System.IO;

namespace VeiculosAPI.Core.Email.Templates.VerificacaoEmail
{
    public class VerificacaoEmail
    {
        private const string path = "Core/Email/Templates/VerificacaoEmail/";
        public static string Template(int id, string nome)
        {
            IConfigurationSection config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiInfo");
            string templateHtml = File.ReadAllText("./" + path + "verificacao-email.html");

            templateHtml = templateHtml.Replace("{nome}", nome);
            templateHtml = templateHtml.Replace("{url}", config["Url"] + $"/v1/usuarios/{id}/verificar-email");

            return templateHtml;
        }
    }
}
