using AutoMapper;
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
    }
}
