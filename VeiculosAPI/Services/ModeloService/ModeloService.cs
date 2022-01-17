using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.DTOs.Modelo;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.ModeloService.Interfaces;

namespace VeiculosAPI.Services.ModeloService
{
    public class ModeloService : BaseService<Modelo, ModeloCreateDTO, ModeloEditDTO>, IModeloService
    {
        public ModeloService(VeiculosDb context, IMapper mapper) : base(context, mapper) { }

        public async override Task<List<Modelo>> GetAll()
        {
            return await base.dbSet.Include(c => c.Marca).ToListAsync();
        }

        public async override Task<Modelo> Get(int id)
        {
            return await base.dbSet.Include(c => c.Marca).FirstAsync(c => c.Id == id);
        }
    }
}
