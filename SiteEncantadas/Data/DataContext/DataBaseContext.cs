using SiteEncantadas.Data.DBCommands.Abstraction;
using SiteEncantadas.Data.DBQuerys.Abstarction;
using System.Data;
using System.Data.SqlClient;

namespace SiteEncantadas.Data.DataContext
{
    public class DataBaseContext
    {
        public IDbConnection connection;
        public ISQLQuerys sqlQuery;
        public ISQLCommands sqlCommand;
        public DataBaseContext(IDbConnection connection, ISQLQuerys siapQuery, ISQLCommands siapCommand)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(DataBaseContext.connection));
            this.sqlQuery = siapQuery ?? throw new ArgumentNullException(nameof(sqlQuery));
            this.sqlCommand = siapCommand ?? throw new ArgumentNullException(nameof(sqlCommand));
        }
    }
}
