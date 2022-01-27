using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Marca
{
    public class MarcaDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Logo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class MarcaCreateDTO : BaseCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        public IFormFile Logo { get; set; }
    }

    public class MarcaEditDTO : BaseEditDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        public IFormFile Logo { get; set; }
    }
}
