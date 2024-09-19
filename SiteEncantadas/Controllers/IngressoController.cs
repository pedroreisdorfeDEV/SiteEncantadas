using Microsoft.AspNetCore.Mvc;
using SiteEncantadas.Business.ReservaService;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;
using System.ComponentModel;
using Newtonsoft.Json;

namespace SiteEncantadas.Controllers
{
    public class IngressoController : Controller
    {
        private readonly ISessao _sessao;
        private readonly IReservaService _reservaService;

        public IngressoController(ISessao sessao, IReservaService reservaService)
        {
            _sessao = sessao;
            _reservaService = reservaService;   
        }

        public IActionResult Reserva()
        {
            Usuario usuario = _sessao.BuscarSessaoUsuario();
            if (usuario != null)
            {
                ViewBag.UsuarioLogado = true;
            }
            else
            {
                ViewBag.UsuarioLogado = false;
            }
            return View(usuario);
        }

        public async Task<List<int>> ObterCadeirasReservadas()
        {
            List<int> listaIDcadeirasReservadas = await _reservaService.ObterCadeirasReservadas();

            return listaIDcadeirasReservadas;
        }

        [HttpPost]
        public IActionResult ReservarIngressos([FromBody] List<int> listaPraReserva)
        {
            return RedirectToAction("IndexPagamento", "Pagamento");

        }
    }
}
