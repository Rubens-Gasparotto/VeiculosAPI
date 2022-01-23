using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeiculosAPI.Repository.DTOs.Permissao;

namespace VeiculosAPI.Repository.DTOs.Usuario
{
    public class UsuarioDTO : BaseDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email{ get; set; }
        public DateTime EmailVerificadoEm { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        public List<PermissaoDTO> Permissoes { get; set; }
    }

    public class UsuarioCreateDTO : BaseCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Compare("Senha")]
        public string ConfirmacaoSenha { get; set; }
    }

    public class UsuarioEditDTO : BaseEditDTO
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
    }

    public class UsuarioEditPermissoesDTO
    {
        [Required]
        public int[] Permissoes { get; set; }
    }
}
