using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using VeiculosAPI.Core.Email;
using VeiculosAPI.Core.Email.Templates.VerificacaoEmail;
using VeiculosAPI.Core.Passwords;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.DTOs.Usuario;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.UsuarioService.Interfaces;

namespace VeiculosAPI.Services.UsuarioService
{
    public class UsuarioService : BaseService<Usuario, UsuarioDTO, UsuarioCreateDTO, UsuarioEditDTO>, IUsuarioService
	{
		public UsuarioService(VeiculosDb context, IMapper mapper) : base(context, mapper) { }

		public override Usuario Create(UsuarioCreateDTO dados)
		{
			Usuario salvarDado = base.mapper.Map<UsuarioCreateDTO, Usuario>(dados);

			salvarDado.Senha = PasswordHasher.Hash(salvarDado.Senha);

			var dadosSalvos = base.context.Usuarios.Add(salvarDado).Entity;

			Save();

			string body = VerificacaoEmail.Template(dadosSalvos.Id, dadosSalvos.Nome);

			Email email = new();
			email.Send("Verificação de e-mail", dadosSalvos.Email, body);

			return dadosSalvos;
		}

		public string VerificarEmail(int id)
		{
			Usuario usuario = base.context.Usuarios.Find(id);

			if (usuario != null && usuario.EmailVerificadoEm == null)
			{
				usuario.EmailVerificadoEm = DateTime.Now;
				Save();

				return "Conta verificada com sucesso!";
			}

			return "Sua conta já foi verificada.";
		}

		public async Task SetPermissoes(int id, UsuarioEditPermissoesDTO dados)
		{
			Usuario usuario = await base.dbSet.AsNoTracking().Include(c => c.Permissoes).FirstAsync(c => c.Id == id);

			usuario.Permissoes.Clear();

			base.dbSet.Update(usuario);

			base.Save();

			foreach (var permissaoId in dados.Permissoes)
			{
				Permissao permissaoAdd = await base.context.Permissoes.AsNoTracking().FirstAsync(permissao => permissao.Id == permissaoId);
				usuario.Permissoes.Add(permissaoAdd);
			}

			base.dbSet.Update(usuario);

			base.Save();
		}
	}
}
