using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using VeiculosAPI.Core.Passwords;
using VeiculosAPI.Repository;
using VeiculosAPI.Services.LoginService.Dtos;

namespace VeiculosAPI.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly VeiculosDb _context;
        private readonly IConfiguration _config;

        public LoginService(VeiculosDb context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }
        public string Login(ILogin dados)
        {
            var sucesso = ChecarCredenciais(dados.email, dados.senha);

            if (sucesso)
            {
                return GerarTokenJwt();
            }
            else
            {
                return null;
            }
        }

        private bool ChecarCredenciais(string email, string senha)
        {
            var usuario = _context.Usuarios.Where(Usuario => Usuario.Email == email).SingleOrDefault();

            if (usuario != null)
            {
                return PasswordHasher.Check(senha, usuario.Senha);
            }
            else
            {
                return false;
            }
        }

        private string GerarTokenJwt()
        {
            var key = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];

            var expiry = DateTime.Now.AddMinutes(120);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: expiry, signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
