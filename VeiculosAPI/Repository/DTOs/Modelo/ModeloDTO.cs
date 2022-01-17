using System;
using System.ComponentModel.DataAnnotations;
using VeiculosAPI.Repository.DTOs.Marca;

namespace VeiculosAPI.Repository.DTOs.Modelo
{
    public class ModeloDTO : ModeloMarcaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        public int InicioFabricacao { get; set; }
        public int FimFabricacao { get; set; }
        [Required]
        [StringLength(255)]
        public string Imagem { get; set; }
        [Required]
        public int MarcaId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }

    public class ModeloMarcaDTO
    {
        public MarcaDTO Marca { get; set; }
    }

    public class ModeloCreateDTO : BaseCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        public int InicioFabricacao { get; set; }
        public int? FimFabricacao { get; set; }
        [Required]
        [StringLength(255)]
        public string Imagem { get; set; }
        [Required]
        public int MarcaId { get; set; }

    }

    public class ModeloEditDTO : BaseEditDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        public int InicioFabricacao { get; set; }
        public int? FimFabricacao { get; set; }
        [Required]
        [StringLength(255)]
        public string Imagem { get; set; }
        [Required]
        public int MarcaId { get; set; }
    }
}
