using Microsoft.AspNetCore.Mvc;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Controllers
{
    public class IngressoController : Controller
    {
        private readonly ISessao _sessao;

        public IngressoController(ISessao sessao)
        {
            _sessao = sessao;
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
    }
}
