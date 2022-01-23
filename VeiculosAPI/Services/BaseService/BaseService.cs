using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

		public virtual List<TDTO> GetAll()
		{
			var items = dbSet.Where(c => c.DeletedAt == null).ToList();

			return mapper.Map<List<T>, List<TDTO>>(items);
		}

		public virtual TDTO Get(int id)
		{
			var item = dbSet.Find(id);

			return mapper.Map<T, TDTO>(item);
		}

		public virtual T Create(TCreateDTO dados)
		{
			T salvarDado = mapper.Map<TCreateDTO, T>(dados);
			var dadosSalvos = dbSet.Add(salvarDado).Entity;

			Save();

			return dadosSalvos;
		}

		public virtual T Update(int id, TEditDTO dados)
		{
			T original = dbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);

			T editarDado = mapper.Map<TEditDTO, T>(dados);

			editarDado.Id = original.Id;
			editarDado.CreatedAt = original.CreatedAt;

			dbSet.Update(editarDado);

			Save();

			return editarDado;
		}

		public virtual bool Delete(int id)
		{
			var entidade = dbSet.Find(id);

			if (entidade.DeletedAt == null)
			{
				dbSet.Remove(entidade);

				Save();

				return true;
			}
			else
			{
				return false;
			}
		}

		public void Save()
        {
			context.SaveChanges();
		}

		public virtual bool Exists(int id)
        {
			return dbSet.Any(c => c.Id == id);
		}

		public virtual List<Permissao> GetPermissoes(int usuarioId)
		{
			var usuario = context.Usuarios.Include(c => c.Permissoes).First(c => c.Id == usuarioId);

			return usuario.Permissoes.ToList();
		}
	}
}
