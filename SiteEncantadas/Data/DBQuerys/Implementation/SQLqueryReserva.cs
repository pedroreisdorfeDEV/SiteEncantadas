using SiteEncantadas.Data.DBQuerys.Abstarction;
using SiteEncantadas.Models.Entities;

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

        public string UpdateStatusReserva(int id)
        {
            string query = $@"UPDATE reserva_ingressos
                SET  cadeira_reservada = 1
                    WHERE
                        ID = {id};";

            return query;
        }
        public string VerificarStatusCadeira(int id)
        {
            string query = $@"SELECT cadeira_reservada
                    FROM
                        reserva_ingressos
                    WHERE
                        id = {id};";

            return query;
        }

    }
}
