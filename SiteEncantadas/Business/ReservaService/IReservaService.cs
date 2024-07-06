using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Business.ReservaService
{
    public interface IReservaService
    {
        Task<Mesas> BuscarEconstruirMesas();
        Task<List<int>> ObterCadeirasReservadas();
    }
}
