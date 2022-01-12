using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("marcas")]
    public class Marca : BaseModel
    {
        [Column(name: "nome")]
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Column(name: "logo")]
        [Required]
        [StringLength(255)]
        public string Logo { get; set; }

        [JsonIgnore]
        public List<Modelo> Modelos { get; set; }
    }
}
