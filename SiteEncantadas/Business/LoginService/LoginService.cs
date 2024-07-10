
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.ViewModels;
using SiteEncantadas.UseCase.UsuarioUseCase.Services.Repositories;

namespace SiteEncantadas.Business.LoginService
{
    public class LoginService : ILoginService
    {

        private readonly Contexto _context;
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginService(Contexto context, IUsuarioRepository usuarioRepository)
        {
            _context = context;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> ValidarUsuario(string login, string senha)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Login = login;
            loginViewModel.Senha = senha;

            Usuario usuario = new Usuario();

            CadastroViewModel cadastro = await _usuarioRepository.ObterUsuario(login, senha);
            if(cadastro == null)
            {
                return null;
            }
            usuario.Cadastro = cadastro;
            usuario.Login = login;
     
            return usuario;

        }
    }
}
