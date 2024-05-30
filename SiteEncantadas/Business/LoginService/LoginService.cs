
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.ViewModels;

namespace SiteEncantadas.Business.LoginService
{
    public class LoginService : ILoginService
    {

        private readonly Contexto _context;

        public LoginService(Contexto context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidarUsuario(string login, string senha)
        {

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Login = login;
            loginViewModel.Senha = senha;

            Usuario usuario = new Usuario();

            List<CadastroViewModel> listaCasdastros = _context.Cadastro.ToList();

            foreach (var item in listaCasdastros)
            {
                if (item.Email == login && item.Senha == senha)
                {
                    usuario.Login = login;
                    usuario.Senha = senha;
                    usuario.Cadastro = item;
                    break;
                }
            }
            return usuario;

        }
    }
}
