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
using System.Threading.Tasks;

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
        public async Task<LoginResponseDTO> Login(LoginDTO dados)
        {
            bool sucesso = await ChecarCredenciais(dados.Email, dados.Senha);

            if (sucesso)
            {
                string token = await GerarTokenJwt(dados.Email);
                string refreshToken = await GerarRefreshTokenJwt(dados.Email);

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

        private async Task<bool> ChecarCredenciais(string email, string senha)
        {
            Usuario usuario = await context.Usuarios.AsNoTracking().SingleAsync(usuario => usuario.Email == email);

            if (usuario != null)
            {
                return PasswordHasher.Check(senha, usuario.Senha);
            }
            else
            {
                return false;
            }
        }

        private async Task<string> GerarTokenJwt(string email)
        {
            byte[] key = Encoding.ASCII.GetBytes(config["Jwt:Key"]);

            var usuario = await context.Usuarios.AsNoTracking().SingleAsync(usuario => usuario.Email == email);
            List<Claim> claimList = new();

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

        private async Task<string> GerarRefreshTokenJwt(string email)
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

            await context.RefreshTokens.AddAsync(new RefreshToken { Token = refreshToken, ExpiraEm = expiraEm });
            await context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<LoginResponseDTO> RefreshToken(string oldRefreshToken)
        {
            RefreshToken refreshToken = await context.RefreshTokens
                .Where(refresh => refresh.Token == oldRefreshToken)
                .Where(refresh => refresh.ExpiraEm > DateTime.Now)
                .Where(refresh => refresh.DeletedAt == null)
                .FirstOrDefaultAsync();

            if (refreshToken != null)
            {
                JwtSecurityTokenHandler handler = new();
                JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(refreshToken.Token);

                string email = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "email").Value;

                string token = await GerarTokenJwt(email);
                string newRefreshToken = await GerarRefreshTokenJwt(email);

                context.Remove(refreshToken);
                await context.SaveChangesAsync();

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
