using SiteEncantadas.Data.DataType;

namespace SiteEncantadas.Data.Connections
{
    public class AppSettingsDbConfiguracao
    {
        public EnumTipoBanco TipoBanco { get; set; }
        public string? ConnectionString { get; set; }
    }
}
