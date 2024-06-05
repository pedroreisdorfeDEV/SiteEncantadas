
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

        public async Task<Usuario> ValidarUsuario(string login, string senha)
        {

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Login = login;
            loginViewModel.Senha = senha;

            Usuario usuario = new Usuario();

            //CadastroViewModel cadastroViewModel = await _usuarioRepository.ObterUsuario(login, senha);

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
