using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Auth
{
    public class LoginResponseDTO
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
