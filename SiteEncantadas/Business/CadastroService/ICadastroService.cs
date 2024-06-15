using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Business.CadastroService
{
    public interface ICadastroService
    {
        Task<bool> VerificarEmailCadastro(string email);
    }
}
