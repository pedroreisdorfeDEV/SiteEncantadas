namespace SiteEncantadas.Data.DBQuerys.Abstarction
{
    public partial interface ISQLQuerys
    {
        public string ObterUsuario(string login, string senha);
    }
}
