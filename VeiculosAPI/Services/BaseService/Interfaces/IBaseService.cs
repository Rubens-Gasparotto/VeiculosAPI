using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeiculosAPI.Services.BaseService.Interfaces
{
    public interface IBaseService<T, TCreateDTO, TEditDTO>
    {
        public Task<List<T>> GetAll();
        public Task<T> Get(int id);
        public T Create(TCreateDTO dados);
        public T Update(int id, TEditDTO dados);
        public bool Delete(int id);
        public bool Exists(int id);
    }
}
