using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("usuarios")]
    public class Usuario : BaseModel
    {
        [Column(name: "nome")]
        public string Nome { get; set; }

        [Column(name: "email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(name: "senha")]
        [DataType(DataType.Password)]
        [JsonIgnore]
        public string Senha { get; set; }

        [Column(name: "email_verificado_em")]
        [DataType(DataType.DateTime)]
        public DateTime? EmailVerificadoEm { get; set; }

        public Permissao[] Permissoes { get; set; }
    }
}
