using FluentValidation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("modelos")]
    public class Modelo : BaseModel
    {
        [Column(name: "nome")]
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Column(name: "inicio_fabricacao")]
        [Required]
        public int InicioFabricacao { get; set; }

        [Column(name: "fim_fabricacao")]
        public int? FimFabricacao { get; set; }

        [Column(name: "imagem")]
        [Required]
        [StringLength(255)]
        public string Imagem { get; set; }

        [Column(name: "marca_id")]
        [Required]
        [ForeignKey("marca_foreign_key")]
        public int MarcaId { get; set; }

        [JsonIgnore]
        public virtual Marca Marca { get; set; }
    }

    public class ModelosValidator : AbstractValidator<Modelo>
    {
        public ModelosValidator(VeiculosDb context)
        {
            RuleFor(modelo => modelo.MarcaId).Must(marcaId => context.Marcas.Find(marcaId) != null).WithMessage("Marca não encontrada.");
            RuleFor(modelo => modelo.InicioFabricacao).NotNull().GreaterThanOrEqualTo(1886).WithMessage("O ano de início de fabricação deve ser igual ou maior a 1886.");
            RuleFor(modelo => modelo.FimFabricacao).GreaterThanOrEqualTo(1886).WithMessage("O ano de fim de fabricação deve ser igual ou maior a 1886.");
        }
    }
}
