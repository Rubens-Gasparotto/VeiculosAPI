using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("usuarios_permissoes")]
    public class UsuarioPermissao : BaseModel
    {
        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int PermissaoId { get; set; }

        public Usuario Usuario { get; set; }

        public Permissao Permissao { get; set; }
    }
}
