using System.Data.SqlClient;

namespace SiteEncantadas.Data.Connections
{
    public interface IConnectionManager

    {
        SqlConnection GetConnection();
    }
}
