using AutoMapper;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.MarcaService.DTOs;
using VeiculosAPI.Services.MarcaService.Interfaces;

namespace VeiculosAPI.Services.MarcaService
{
    public class MarcaService : BaseService<Marca, MarcaCreateDTO, MarcaEditDTO>, IMarcaService
    {
        public MarcaService(VeiculosDb context, IMapper mapper) : base(context, mapper) { }
    }
}
