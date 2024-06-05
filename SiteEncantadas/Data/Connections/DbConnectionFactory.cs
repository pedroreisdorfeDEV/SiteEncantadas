using SiteEncantadas.Data.DataContext;
using SiteEncantadas.Data.DataType;
using SiteEncantadas.Data.DBCommands.Abstraction;
using SiteEncantadas.Data.DBCommands.Implementation;
using SiteEncantadas.Data.DBQuerys.Abstarction;
using SiteEncantadas.Data.DBQuerys.Implementation;
using System.Data;

namespace SiteEncantadas.Data.Connections
{
    public class DbConnectionFactory : IDataBaseConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration) => _configuration = configuration;

        public DataBaseContext ObterContexto(string AppSettingsSection)
        {
            IConfigurationSection configuracaoSessao = _configuration.GetSection(AppSettingsSection);
            AppSettingsDbConfiguracao configSessao = new();
            ConnectionManager connectionManager = new();
            configuracaoSessao.Bind(configSessao);

            IDbConnection dbConnection;
            ISQLCommands sqlCommands;
            ISQLQuerys sqlQuerys;

            switch (configSessao.TipoBanco)
            {
                case EnumTipoBanco.SQLServer:
                    dbConnection = connectionManager.GetConnection();
                    sqlQuerys = new SQLQuerys();
                    sqlCommands = new SQLCommands();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new DataBaseContext(dbConnection, sqlQuerys, sqlCommands);
        }
    }
}
