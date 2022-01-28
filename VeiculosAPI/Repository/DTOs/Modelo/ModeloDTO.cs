using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using VeiculosAPI.Repository.DTOs.Marca;

namespace VeiculosAPI.Repository.DTOs.Modelo
{
    public class ModeloDTO : ModeloMarcaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int InicioFabricacao { get; set; }
        public Nullable<int> FimFabricacao { get; set; }
        public string Imagem { get; set; }
        public int MarcaId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class ModeloMarcaDTO : BaseDTO
    {
        public MarcaDTO Marca { get; set; }
    }

    public class ModeloCreateDTO : BaseCreateDTO
    {
        [Required, StringLength(255)]
        public string Nome { get; set; }
        [Required]
        public int InicioFabricacao { get; set; }
        public Nullable<int> FimFabricacao { get; set; }
        [Required]
        public IFormFile Imagem { get; set; }
        [Required]
        public int MarcaId { get; set; }

    }

    public class ModeloEditDTO : BaseEditDTO
    {
        [Required, StringLength(255)]
        public string Nome { get; set; }
        [Required]
        public int InicioFabricacao { get; set; }
        public Nullable<int> FimFabricacao { get; set; }
        public IFormFile Imagem { get; set; }
        [Required]
        public int MarcaId { get; set; }
    }
}
