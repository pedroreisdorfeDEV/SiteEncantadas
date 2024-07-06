
using Dapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SiteEncantadas.Data.Connections;
using SiteEncantadas.Data.Constantes;
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Data.DataContext;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.Entities.Reserva;
using SiteEncantadas.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SiteEncantadas.UseCase.ReservaUseCase.Services.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDataBaseConnectionFactory _dataBaseConnectionFactory;
        private readonly DataBaseContext _dbContext;
        private readonly Contexto _context;

        public ReservaRepository(IConfiguration configuration, IDataBaseConnectionFactory dataBaseConnectionFactory, Contexto context)
        {
            _configuration = configuration;
            _dataBaseConnectionFactory = dataBaseConnectionFactory;
            _dbContext = _dataBaseConnectionFactory.ObterContexto(AppSettingsConstantes.DB_SQL);
            _context = context;
        }

        public async Task<List<Reserva_ingressos>> BuscarMesas()
        {
            List<Reserva_ingressos> mesas = _context.reserva_ingressos.ToList();

            return mesas;
        }

        public async Task<List<int>> ObterCadeirasReservadas()
        {
            IEnumerable<int> listaIdCadeirasReservadas = await _dbContext.connection.QueryAsync<int>(_dbContext.sqlQuery.ObterCadeirasReservadas());
            return listaIdCadeirasReservadas.ToList();
        }
    }
}
