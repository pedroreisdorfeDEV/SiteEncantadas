namespace SiteEncantadas.Models.Entities.Reserva
{
    public class Reserva_ingressos
    {
        public int ID { get; set; }
        public int num_mesa { get; set; }
        public int num_cadeira { get; set; }
        public int cadeira_reservada { get; set; }
        public decimal valor_cadeira { get; set; }
    }
}
