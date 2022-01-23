using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public override List<ModeloDTO> GetAll()
        {
            var modelos = base.dbSet.Include(c => c.Marca).ToList();

            return this.mapper.Map<List<Modelo>, List<ModeloDTO>>(modelos);
        }

        public override ModeloDTO Get(int id)
        {
            var modelo = base.dbSet.Include(c => c.Marca).First(c => c.Id == id);

            return this.mapper.Map<Modelo, ModeloDTO>(modelo);
        }
    }
}
