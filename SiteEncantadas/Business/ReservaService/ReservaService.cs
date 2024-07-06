using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.UseCase.ReservaUseCase.Services.Repositories;

namespace SiteEncantadas.Business.ReservaService
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        //private readonly Contexto _context;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }


        public async Task<Mesas> BuscarEconstruirMesas()
        {
            List<Models.Entities.Reserva.Reserva_ingressos> mesasDB = await _reservaRepository.BuscarMesas();

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

        public async Task<List<int>> ObterCadeirasReservadas()
        {
            List<int> listaCadeirasReservadas = new List<int>();

            listaCadeirasReservadas = await _reservaRepository.ObterCadeirasReservadas();

            if (listaCadeirasReservadas == null)
            {
                listaCadeirasReservadas.Add(0);
            }

            return listaCadeirasReservadas;
        }
    }
}
