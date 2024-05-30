using SiteEncantadas.Models.Entities.Reserva;

namespace SiteEncantadas.Models.Entities
{
    public class Mesas
    {
        public List<Reserva_ingressos> Mesa1 { get; set; }
        public List<Reserva_ingressos> Mesa2 { get; set; }
        public List<Reserva_ingressos> Mesa3 { get; set; }
        public List<Reserva_ingressos> Mesa4 { get; set; }

        public Mesas()
        {
            Mesa1 = new List<Reserva_ingressos>();
            Mesa2 = new List<Reserva_ingressos>();
            Mesa3 = new List<Reserva_ingressos>();
            Mesa4 = new List<Reserva_ingressos>();
        }
    }
}
