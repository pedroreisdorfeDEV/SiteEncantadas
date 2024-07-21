using SiteEncantadas.Models.Entities.Reserva;
using SiteEncantadas.Models.ViewModels;

namespace SiteEncantadas.Models.Entities
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public CadastroViewModel Cadastro { get; set; }
        public List<Reserva_ingressos> ListaReservas { get; set; }
    }
}
