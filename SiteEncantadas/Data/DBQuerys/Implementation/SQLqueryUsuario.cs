using SiteEncantadas.Data.DBQuerys.Abstarction;

namespace SiteEncantadas.Data.DBQuerys.Implementation
{
    public partial class SQLQuerys : ISQLQuerys
    {
        public string ObterUsuario(string login, string senha)
        {
            string query = $@"SELECT *
                    FROM
                        Cadastro
                    WHERE
                        Email = '{login}' AND
                        Senha = '{senha}';";

            return query;
        }
    }
}
