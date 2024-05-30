using Microsoft.EntityFrameworkCore;
using SiteEncantadas.Models.Entities.Reserva;
using SiteEncantadas.Models.ViewModels;

namespace SiteEncantadas.Data.Contexts
{
    public class Contexto : DbContext
    {
        public DbSet<CadastroViewModel> Cadastro { get; set; }
        public DbSet<LoginViewModel> login_usuario { get; set; }
        public DbSet<Reserva_ingressos> reserva_ingressos { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
