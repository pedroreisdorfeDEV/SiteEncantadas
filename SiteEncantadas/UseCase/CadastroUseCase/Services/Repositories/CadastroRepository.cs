using Dapper;
using SiteEncantadas.Data.Connections;
using SiteEncantadas.Data.Constantes;
using SiteEncantadas.Data.DataContext;
using SiteEncantadas.Models.ViewModels;

namespace SiteEncantadas.UseCase.CadastroUseCase.Services.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDataBaseConnectionFactory _dataBaseConnectionFactory;
        private readonly DataBaseContext _dbContext;

        public CadastroRepository(IConfiguration configuration, IDataBaseConnectionFactory dataBaseConnectionFactory)
        {
            _configuration = configuration;
            _dataBaseConnectionFactory = dataBaseConnectionFactory;
            _dbContext = _dataBaseConnectionFactory.ObterContexto(AppSettingsConstantes.DB_SQL);
        }

        public async Task<bool> VerificarEmailExistente(string email)
        {
            CadastroViewModel cadastroViewModel = await _dbContext.connection.QuerySingleOrDefaultAsync<CadastroViewModel>(_dbContext.sqlQuery.VerificarEmailExistente(email));

            if(cadastroViewModel != null)
            {
                return true;
            }

            return false;
        }
    }
}
