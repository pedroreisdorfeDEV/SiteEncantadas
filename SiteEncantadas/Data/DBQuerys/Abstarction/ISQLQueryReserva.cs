namespace SiteEncantadas.Data.DBQuerys.Abstarction
{

    public partial interface ISQLQuerys
    {
        public string ObterCadeirasReservadas();
        public string UpdateStatusReserva(int id);
        public string VerificarStatusCadeira(int id);
    }
}
