using System.Collections.Generic;

namespace VeiculosAPI.Services.BaseService.Interfaces
{
    public interface IBaseService<T, TCreateDTO, TEditDTO>
    {
        public List<T> GetAll();
        public T Get(int id);
        public T Create(TCreateDTO dados);
        public T Update(int id, TEditDTO dados);
        public bool Delete(int id);
        public bool Exists(int id);
    }
}
