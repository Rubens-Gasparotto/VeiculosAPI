using FluentValidation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("modelos")]
    public class Modelo : BaseModel
    {
        [Required, Column("nome"), StringLength(255)]
        public string Nome { get; set; }

        [Required, Column("inicio_fabricacao")]
        public int InicioFabricacao { get; set; }

        [Column("fim_fabricacao")]
        public int? FimFabricacao { get; set; }

        [Required, Column("imagem"), StringLength(255)]
        public string Imagem { get; set; }

        [Required, Column("marca_id"), ForeignKey("marca_foreign_key")]
        public int MarcaId { get; set; }

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
