
using SiteEncantadas.Data.Contexts;

namespace SiteEncantadas.Models.Entities.Reserva
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly Contexto _context;
        public ReservaRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<List<Reserva_ingressos>> BuscarMesas()
        {
            List<Reserva_ingressos> mesas = _context.reserva_ingressos.ToList();

            return mesas;
        }
    }
}
