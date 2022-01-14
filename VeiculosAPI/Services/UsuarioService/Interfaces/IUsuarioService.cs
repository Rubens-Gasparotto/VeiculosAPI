using VeiculosAPI.Repository.DTOs.Usuario;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Services.UsuarioService.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario, UsuarioCreateDTO, UsuarioEditDTO>
    {
        public string VerificarEmail(int id);
    }
}
