using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Business.LoginService
{
    public interface ILoginService
    {
        Task<Usuario> ValidarUsuario(string login, string senha);
    }
}
