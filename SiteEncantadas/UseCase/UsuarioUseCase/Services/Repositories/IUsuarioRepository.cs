using SiteEncantadas.Models.ViewModels;

namespace SiteEncantadas.UseCase.UsuarioUseCase.Services.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<CadastroViewModel> ObterUsuario(string login, string senha);
    }
}
