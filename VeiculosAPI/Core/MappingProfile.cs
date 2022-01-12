using AutoMapper;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.MarcaService.DTOs;
using VeiculosAPI.Services.ModeloService.DTOs;

namespace VeiculosAPI.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Marca, MarcaCreateDTO>();
            CreateMap<Marca, MarcaEditDTO>();
            CreateMap<Marca, MarcaDTO>();

            CreateMap<Modelo, ModeloCreateDTO>();
            CreateMap<Modelo, ModeloEditDTO>();
            CreateMap<Modelo, ModeloDTO>();
        }
    }
}
