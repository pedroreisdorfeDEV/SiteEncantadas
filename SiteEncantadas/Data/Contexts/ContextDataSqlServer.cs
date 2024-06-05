using SiteEncantadas.Data.Connections;
using System.Data.SqlClient;

namespace SiteEncantadas.Data.Contexts
{
    public class ContextDataSqlServer : IContextData
    {
        private readonly SqlConnection _connection = null;

        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }

    }
}
