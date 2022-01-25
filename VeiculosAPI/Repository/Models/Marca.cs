using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("marcas")]
    public class Marca : BaseModel
    {
        [Required, Column("nome"), StringLength(255)]
        public string Nome { get; set; }

        [Required, Column("logo"), StringLength(255)]
        public string Logo { get; set; }

        public virtual List<Modelo> Modelos { get; set; }
    }
}
