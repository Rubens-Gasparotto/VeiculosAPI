using VeiculosAPI.Repository.DTOs.Auth;

namespace VeiculosAPI.Services.AuthService
{
    public interface IAuthService
    {
        public LoginResponseDTO Login(LoginDTO dados);
        public LoginResponseDTO RefreshToken(string token);
    }
}
