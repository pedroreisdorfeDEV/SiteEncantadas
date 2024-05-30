using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SiteEncantadas.Data.Connections
{
    public class ConnectionManager : IConnectionManager
    {
        private static string stringDeConexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_Encantadas_teste;Data Source=LAPTOP-8RL84DG9\MSSQLSERVER01";

        public static SqlConnection connection = null;

        public ConnectionManager()
        {
            connection = new SqlConnection(stringDeConexao);
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
