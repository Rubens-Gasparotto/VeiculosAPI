using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.DTOs;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Services.BaseService
{
    public class BaseService<T, TDTO, TCreateDTO, TEditDTO> : IBaseService<T, TDTO, TCreateDTO, TEditDTO> where T : BaseModel where TDTO : BaseDTO where TCreateDTO : BaseCreateDTO where TEditDTO : BaseEditDTO
	{
		public readonly VeiculosDb context;
		public readonly DbSet<T> dbSet;
		public readonly IMapper mapper;
		public BaseService(VeiculosDb _context, IMapper _mapper)
		{
			context = _context;
			mapper = _mapper;
			dbSet = context.Set<T>();
		}

		public async virtual Task<List<TDTO>> GetAll()
		{
			var items = await dbSet.Where(c => c.DeletedAt == null).ToListAsync();

			return mapper.Map<List<T>, List<TDTO>>(items);
		}

		public async virtual Task<TDTO> Get(int id)
		{
			var item = await dbSet.FindAsync(id);

			return mapper.Map<T, TDTO>(item);
		}

		public async virtual Task<T> Create(TCreateDTO dados)
		{
			T salvarDado = mapper.Map<TCreateDTO, T>(dados);
			var dadosSalvos = await dbSet.AddAsync(salvarDado);

			await Save();

			return dadosSalvos.Entity;
		}

		public async virtual Task<T> Update(int id, TEditDTO dados)
		{
			T original = await dbSet.FirstAsync(c => c.Id == id);

			T editarDado = mapper.Map<TEditDTO, T>(dados);

			editarDado.Id = original.Id;
			editarDado.CreatedAt = original.CreatedAt;

			dbSet.Update(editarDado);

			await Save();

			return editarDado;
		}

		public async virtual Task<bool> Delete(int id)
		{
			var entidade = await dbSet.FindAsync(id);

			if (entidade.DeletedAt == null)
			{
				dbSet.Remove(entidade);

				await Save();

				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<int> Save()
        {
			return await context.SaveChangesAsync();
		}

		public async virtual Task<bool> Exists(int id)
        {
			return await dbSet.AnyAsync(c => c.Id == id);
		}

		public async virtual Task<List<Permissao>> GetPermissoes(int usuarioId)
		{
			var usuario = await context.Usuarios.AsNoTracking().Include(c => c.Permissoes).FirstAsync(c => c.Id == usuarioId);

			return usuario.Permissoes.Where(c => c.DeletedAt == null).ToList();
		}
	}
}
