using AutoMapper;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.DTOs.Permissao;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.PermissaoService.Interfaces;

namespace VeiculosAPI.Services.PermissaoService
{
    public class PermissaoService : BaseService<Permissao, PermissaoDTO, PermissaoCreateDTO, PermissaoEditDTO>, IPermissaoService
    {
        public PermissaoService(VeiculosDb context, IMapper mapper) : base(context, mapper) { }
    }
}
