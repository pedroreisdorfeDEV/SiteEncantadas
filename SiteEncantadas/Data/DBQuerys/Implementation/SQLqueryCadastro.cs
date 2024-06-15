using SiteEncantadas.Data.DBQuerys.Abstarction;

namespace SiteEncantadas.Data.DBQuerys.Implementation
{
    public partial class SQLQuerys : ISQLQuerys
    {
        public string VerificarEmailExistente(string email)
        {
            string query = $@"SELECT *
                    FROM
                        Cadastro
                    WHERE
                        Email = '{email}';";

            return query;
        }
    }
}
