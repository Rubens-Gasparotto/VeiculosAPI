using System;
using System.Linq;
using System.Text;
using System.Security.Claims;
using VeiculosAPI.Repository;
using VeiculosAPI.Core.Passwords;
using VeiculosAPI.Repository.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using VeiculosAPI.Repository.DTOs.Auth;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace VeiculosAPI.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly VeiculosDb context;
        private readonly IConfiguration config;

        public AuthService(VeiculosDb _context, IConfiguration _configuration)
        {
            context = _context;
            config = _configuration;
        }
        public LoginResponseDTO Login(LoginDTO dados)
        {
            bool sucesso = ChecarCredenciais(dados.Email, dados.Senha);

            if (sucesso)
            {
                string token = GerarTokenJwt(dados.Email);
                string refreshToken = GerarRefreshTokenJwt(dados.Email);

                return new LoginResponseDTO()
                {
                    Token = token,
                    RefreshToken = refreshToken
                };
            }
            else
            {
                return null;
            }
        }

        private bool ChecarCredenciais(string email, string senha)
        {
            Usuario usuario = context.Usuarios.AsNoTracking().Where(Usuario => Usuario.Email == email).SingleOrDefault();

            if (usuario != null)
            {
                return PasswordHasher.Check(senha, usuario.Senha);
            }
            else
            {
                return false;
            }
        }

        private string GerarTokenJwt(string email)
        {
            byte[] key = Encoding.ASCII.GetBytes(config["Jwt:Key"]);

            var usuario = context.Usuarios.AsNoTracking().Include(usuario => usuario.Permissoes).Where(usuario => usuario.Email == email).SingleOrDefault();
            var claimList = new List<Claim>();

            claimList.Add(new Claim(ClaimTypes.Email, email));
            claimList.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string authToken = tokenHandler.WriteToken(token);

            return authToken;
        }

        private string GerarRefreshTokenJwt(string email)
        {
            DateTime expiraEm = DateTime.Now.AddDays(1);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = expiraEm
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string refreshToken = tokenHandler.WriteToken(token);

            context.RefreshTokens.Add(new RefreshToken { Token = refreshToken, ExpiraEm = expiraEm });
            context.SaveChanges();

            return refreshToken;
        }

        public LoginResponseDTO RefreshToken(string oldRefreshToken)
        {
            RefreshToken refreshToken = context.RefreshTokens
                .Where(refresh => refresh.Token == oldRefreshToken)
                .Where(refresh => refresh.ExpiraEm > DateTime.Now)
                .Where(refresh => refresh.DeletedAt == null)
                .FirstOrDefault();

            if (refreshToken != null)
            {
                JwtSecurityTokenHandler handler = new();
                JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(refreshToken.Token);

                string email = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "email").Value;

                string token = GerarTokenJwt(email);
                string newRefreshToken = GerarRefreshTokenJwt(email);

                context.Remove(refreshToken);
                context.SaveChanges();

                return new LoginResponseDTO()
                {
                    Token = token,
                    RefreshToken = newRefreshToken
                };
            }
            else
            {
                return null;
            }
        }
    }
}
