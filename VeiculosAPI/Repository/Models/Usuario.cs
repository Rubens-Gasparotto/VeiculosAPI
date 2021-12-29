using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "nome")]
        public string Nome { get; set; }

        [Column(name: "email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(name: "senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Column(name: "email_verificado_em")]
        [DataType(DataType.DateTime)]
        public DateTime? EmailVerificadoEm { get; set; }

        [Column(name: "created_at")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; }

        [Column(name: "updated_at")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        [Column(name: "deleted_at")]
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }
    }
}
