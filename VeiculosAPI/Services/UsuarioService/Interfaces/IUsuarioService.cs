using System.Threading.Tasks;
using VeiculosAPI.Repository.DTOs.Usuario;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Services.UsuarioService.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario, UsuarioDTO, UsuarioCreateDTO, UsuarioEditDTO>
    {
        public Task<string> VerificarEmail(int id);
        public Task SetPermissoes(int id, UsuarioEditPermissoesDTO permissoes);
    }
}
