using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("usuarios_permissoes")]
    public class UsuarioPermissao
    {
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("permissao_id")]
        public int PermissaoId { get; set; }

        public Usuario Usuario { get; set; }
        public Permissao Permissao { get; set; }
    }
}
