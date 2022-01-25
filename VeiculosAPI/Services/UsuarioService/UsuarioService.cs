using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async override Task<UsuarioDTO> Get(int id)
        {
            var usuario = await dbSet.Include(c => c.Permissoes).FirstAsync(c => c.Id == id);

            return mapper.Map<Usuario, UsuarioWithPermissaoDTO>(usuario);
        }

        public async override Task<Usuario> Create(UsuarioCreateDTO dados)
		{
			Usuario salvarDado = mapper.Map<UsuarioCreateDTO, Usuario>(dados);

			salvarDado.Senha = PasswordHasher.Hash(salvarDado.Senha);

			var dadosSalvos = await context.Usuarios.AddAsync(salvarDado);

			await Save();

			string body = VerificacaoEmail.Template(dadosSalvos.Entity.Id, dadosSalvos.Entity.Nome);

			Email email = new();
			email.Send("Verificação de e-mail", dadosSalvos.Entity.Email, body);

			return dadosSalvos.Entity;
		}

		public async Task<string> VerificarEmail(int id)
		{
			Usuario usuario = await context.Usuarios.FirstAsync(u => u.Id == id);

			if (usuario != null && usuario.EmailVerificadoEm == null)
			{
				usuario.EmailVerificadoEm = DateTime.Now;

				await Save();

				return "Conta verificada com sucesso!";
			}

			return "Sua conta já foi verificada.";
		}

		public async Task SetPermissoes(int id, UsuarioEditPermissoesDTO dados)
		{
			Usuario usuario = await dbSet.Include(c => c.Permissoes).FirstAsync(u => u.Id == id);

			usuario.Permissoes.Clear();

            foreach (var permissaoId in dados.Permissoes)
            {
                Permissao permissaoAdd = await context.Permissoes.FindAsync(permissaoId);
                usuario.Permissoes.Add(permissaoAdd);
            }

			dbSet.Update(usuario);

            await Save();
        }
	}
}
