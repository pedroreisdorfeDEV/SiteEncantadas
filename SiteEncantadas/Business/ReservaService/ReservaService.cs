using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.Entities.Reserva;

namespace SiteEncantadas.Business.ReservaService
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ISessao _sessao;

        public ReservaService(IReservaRepository reservaRepository, ISessao sessao)
        {
            _reservaRepository = reservaRepository;
            _sessao = sessao;
        }

        public async Task<Mesas> BuscarEconstruirMesas()
        {
            List<Reserva_ingressos> mesasDB = await _reservaRepository.BuscarMesas();

            Mesas mesas = new Mesas();

            for (int i = 0; i < mesasDB.Count; i++)
            {
                if (mesasDB[i].num_mesa == 1)
                {
                    mesas.Mesa1.Add(mesasDB[i]);
                }

                if (mesasDB[i].num_mesa == 2)
                {
                    mesas.Mesa2.Add(mesasDB[i]);
                }

                if (mesasDB[i].num_mesa == 2)
                {
                    mesas.Mesa3.Add(mesasDB[i]);
                }

                if (mesasDB[i].num_mesa == 4)
                {
                    mesas.Mesa4.Add(mesasDB[i]);
                }
            }

            return mesas;
        }
    }
}
