using System;
using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Marca
{
    public class MarcaDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }

    public class MarcaCreateDTO : BaseCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Logo { get; set; }
    }

    public class MarcaEditDTO : BaseEditDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Logo { get; set; }
    }
}
