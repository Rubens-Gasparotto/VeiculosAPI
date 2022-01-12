using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Auth
{
    public class RefreshDTO
    {
        [Required]
        public string Token { get; set; }
    }
}
