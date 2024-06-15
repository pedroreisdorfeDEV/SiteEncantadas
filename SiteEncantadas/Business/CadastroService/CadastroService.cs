
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.UseCase.CadastroUseCase.Services.Repositories;

namespace SiteEncantadas.Business.CadastroService
{
    public class CadastroService : ICadastroService
    {
        private readonly Contexto _context;
        private readonly ICadastroRepository _cadastroRepository;

        public CadastroService(Contexto context, ICadastroRepository cadastroRepository)
        {
            _context = context;
            _cadastroRepository = cadastroRepository;
        }

        public async Task<bool> VerificarEmailCadastro(string email)
        {
            bool existeEmailJaCadastrado = await _cadastroRepository.VerificarEmailExistente(email);
        
            return existeEmailJaCadastrado;
        }
    }
}
