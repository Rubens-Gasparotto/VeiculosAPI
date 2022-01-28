using System.Collections.Generic;
using System.Threading.Tasks;
using VeiculosAPI.Repository.DTOs.Paginacao;
using VeiculosAPI.Repository.Models;

namespace VeiculosAPI.Services.BaseService.Interfaces
{
    public interface IBaseService<T, TDTO, TCreateDTO, TEditDTO>
    {
        public Task<List<TDTO>> GetAll();
        public Task<PaginacaoResponseDTO<TDTO>> GetAllPaginate(PaginacaoDTO dadosPaginacao);
        public Task<TDTO> Get(int id);
        public Task<TDTO> Create(TCreateDTO dados);
        public Task<TDTO> Update(int id, TEditDTO dados);
        public Task<bool> Delete(int id);
        public Task<bool> Exists(int id);
        public Task<List<Permissao>> GetPermissoes(int usuarioId);
    }
}
