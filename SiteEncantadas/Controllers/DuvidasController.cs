using Microsoft.AspNetCore.Mvc;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Controllers
{
    public class DuvidasController : Controller
    {
        private readonly ISessao _sessao;

        public DuvidasController(ISessao sessao)
        {
            _sessao = sessao;
        }

        public IActionResult Duvidas()
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
