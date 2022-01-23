using VeiculosAPI.Repository.DTOs.Permissao;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Services.PermissaoService.Interfaces
{
    public interface IPermissaoService : IBaseService<Permissao, PermissaoDTO, PermissaoCreateDTO, PermissaoEditDTO> { }
}
