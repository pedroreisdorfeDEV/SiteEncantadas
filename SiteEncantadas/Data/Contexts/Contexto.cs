using Microsoft.EntityFrameworkCore;
using SiteEncantadas.Models.Entities.Reserva;
using SiteEncantadas.Models.ViewModels;

namespace SiteEncantadas.Data.Contexts
{
    public class Contexto : DbContext
    {
        public DbSet<CadastroViewModel> Cadastro { get; set; }
        //public DbSet<LoginViewModel> login_usuario { get; set; }
        public DbSet<Reserva_ingressos> reserva_ingressos { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_Encantadas_teste;Data Source=LAPTOP-8RL84DG9\MSSQLSERVER01;Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
