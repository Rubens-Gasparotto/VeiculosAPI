using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("permissoes")]
    public class Permissao : BaseModel
    {
        [Required]
        [StringLength(255)]
        [Column(name: "nome")]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        [Column(name: "tipo")]
        public string Tipo { get; set; }
        [Required]
        [StringLength(255)]
        [Column(name: "slug")]
        public string Slug { get; set; }
    }
}
