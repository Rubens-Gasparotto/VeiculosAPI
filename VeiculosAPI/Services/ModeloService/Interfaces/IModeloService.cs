using VeiculosAPI.Repository.DTOs.Modelo;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Services.ModeloService.Interfaces
{
    public interface IModeloService : IBaseService<Modelo, ModeloCreateDTO, ModeloEditDTO> { }
}
