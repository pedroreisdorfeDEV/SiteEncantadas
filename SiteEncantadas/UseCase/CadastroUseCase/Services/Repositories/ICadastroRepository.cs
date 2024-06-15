using SiteEncantadas.Models.ViewModels;

namespace SiteEncantadas.UseCase.CadastroUseCase.Services.Repositories
{
    public interface ICadastroRepository
    {
        public Task<bool> VerificarEmailExistente(string email);
    }
}
