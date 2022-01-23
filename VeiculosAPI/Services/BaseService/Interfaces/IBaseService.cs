using System.Collections.Generic;
using VeiculosAPI.Repository.Models;

namespace VeiculosAPI.Services.BaseService.Interfaces
{
    public interface IBaseService<T, TDTO, TCreateDTO, TEditDTO>
    {
        public List<TDTO> GetAll();
        public TDTO Get(int id);
        public T Create(TCreateDTO dados);
        public T Update(int id, TEditDTO dados);
        public bool Delete(int id);
        public bool Exists(int id);
        public List<Permissao> GetPermissoes(int usuarioId);
    }
}
