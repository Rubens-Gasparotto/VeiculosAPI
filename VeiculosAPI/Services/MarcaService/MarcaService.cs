using AutoMapper;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.DTOs.Marca;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.MarcaService.Interfaces;

namespace VeiculosAPI.Services.MarcaService
{
    public class MarcaService : BaseService<Marca, MarcaDTO, MarcaCreateDTO, MarcaEditDTO>, IMarcaService
    {
        public MarcaService(VeiculosDb context, IMapper mapper) : base(context, mapper) { }
    }
}
