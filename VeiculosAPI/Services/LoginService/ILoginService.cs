using VeiculosAPI.Services.LoginService.Dtos;

namespace VeiculosAPI.Services.LoginService
{
    public interface ILoginService
    {
        public string Login(ILogin dados);
    }
}
