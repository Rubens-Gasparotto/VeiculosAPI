using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Auth
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
