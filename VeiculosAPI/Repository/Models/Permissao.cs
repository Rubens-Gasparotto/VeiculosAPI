using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("permissoes")]
    public class Permissao : BaseModel
    {
        [Required, Column("nome"), StringLength(255)]
        public string Nome { get; set; }

        [Required, Column("tipo"), StringLength(255)]
        public string Tipo { get; set; }

        [Required, Column("slug"), StringLength(255)]
        public string Slug { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
