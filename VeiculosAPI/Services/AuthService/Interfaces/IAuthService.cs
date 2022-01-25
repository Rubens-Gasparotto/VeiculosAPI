using System.Threading.Tasks;
using VeiculosAPI.Repository.DTOs.Auth;

namespace VeiculosAPI.Services.AuthService
{
    public interface IAuthService
    {
        public Task<LoginResponseDTO> Login(LoginDTO dados);
        public Task<LoginResponseDTO> RefreshToken(string token);
    }
}
