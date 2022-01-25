using System;
using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Permissao
{
    public class PermissaoDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class PermissaoCreateDTO : BaseCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(255)]
        public string Slug { get; set; }
    }

    public class PermissaoEditDTO : BaseEditDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(255)]
        public string Slug { get; set; }
    }
}
