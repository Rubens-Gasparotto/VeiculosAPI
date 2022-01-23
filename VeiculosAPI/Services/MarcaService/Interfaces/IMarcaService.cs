using VeiculosAPI.Repository.DTOs.Marca;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Services.MarcaService.Interfaces
{
    public interface IMarcaService : IBaseService<Marca, MarcaDTO, MarcaCreateDTO, MarcaEditDTO> { }
}
