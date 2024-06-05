using SiteEncantadas.Data.DataContext;

namespace SiteEncantadas.Data.Connections
{
    public interface IDataBaseConnectionFactory
    {
        DataBaseContext ObterContexto(string AppSettingsSection);
    }
}
