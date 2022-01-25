using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.DTOs.Modelo;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.ModeloService.Interfaces;

namespace VeiculosAPI.Services.ModeloService
{
    public class ModeloService : BaseService<Modelo, ModeloDTO, ModeloCreateDTO, ModeloEditDTO>, IModeloService
    {
        public ModeloService(VeiculosDb context, IMapper mapper) : base(context, mapper) { }

        public async override Task<List<ModeloDTO>> GetAll()
        {
            var modelos = await dbSet.Include(c => c.Marca).ToListAsync();

            return this.mapper.Map<List<Modelo>, List<ModeloDTO>>(modelos);
        }

        public async override Task<ModeloDTO> Get(int id)
        {
            var modelo = await dbSet.Include(c => c.Marca).FirstAsync(c => c.Id == id);

            return this.mapper.Map<Modelo, ModeloDTO>(modelo);
        }
    }
}
