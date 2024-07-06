using SiteEncantadas.Data.DBQuerys.Abstarction;

namespace SiteEncantadas.Data.DBQuerys.Implementation
{
    public partial class SQLQuerys : ISQLQuerys
    {
        public string ObterCadeirasReservadas()
        {
            string query = $@"SELECT id
                    FROM
                        reserva_ingressos
                    WHERE
                        cadeira_reservada = 1;";

            return query;
        }
    }
}
