using System;
using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Permissao
{
    public class PermissaoDTO : BaseDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
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
