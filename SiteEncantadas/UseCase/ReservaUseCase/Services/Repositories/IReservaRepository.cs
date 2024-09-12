using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.Entities.Reserva;

namespace SiteEncantadas.UseCase.ReservaUseCase.Services.Repositories
{
    public interface IReservaRepository
    {
        Task<List<int>> ObterCadeirasReservadas();
        Task<List<Reserva_ingressos>> BuscarMesas();
        Task<bool> ReservarIngresso(Usuario usuario);
        Task<bool> VerificarStatusAssento(int id);

    }
}
