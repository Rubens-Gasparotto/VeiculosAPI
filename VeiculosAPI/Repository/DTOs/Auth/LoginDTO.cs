using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Auth
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
