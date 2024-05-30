namespace SiteEncantadas.Models.Entities.Reserva
{
    public interface IReservaRepository
    {
        Task<List<Reserva_ingressos>> BuscarMesas();
    }
}
