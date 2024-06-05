using Dapper;
using SiteEncantadas.Data.Connections;
using SiteEncantadas.Data.Constantes;
using SiteEncantadas.Data.DataContext;
using SiteEncantadas.Models.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace SiteEncantadas.UseCase.UsuarioUseCase.Services.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDataBaseConnectionFactory _dataBaseConnectionFactory;
        private readonly DataBaseContext _dbContext;

        public UsuarioRepository(IConfiguration configuration, IDataBaseConnectionFactory dataBaseConnectionFactory)
        {
            _configuration = configuration;
            _dataBaseConnectionFactory = dataBaseConnectionFactory;
            _dbContext = _dataBaseConnectionFactory.ObterContexto(AppSettingsConstantes.DB_SQL);
        }

        public async Task<CadastroViewModel> ObterUsuario(string login, string senha)
        {
            CadastroViewModel cadastroViewModel = await _dbContext.connection.QuerySingleOrDefaultAsync<CadastroViewModel>(_dbContext.sqlQuery.ObterUsuario(login, senha));

            return cadastroViewModel;
        }

    }
}



