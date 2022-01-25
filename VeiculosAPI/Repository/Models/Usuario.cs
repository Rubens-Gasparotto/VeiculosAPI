using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("usuarios")]
    public class Usuario : BaseModel
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column("senha"), DataType(DataType.Password)]
        public string Senha { get; set; }

        [Column("email_verificado_em"), DataType(DataType.DateTime)]
        public DateTime? EmailVerificadoEm { get; set; }

        public ICollection<Permissao> Permissoes { get; set; }
    }
}
