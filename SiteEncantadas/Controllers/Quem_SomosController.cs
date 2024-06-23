using Microsoft.AspNetCore.Mvc;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Controllers
{
    public class Quem_SomosController : Controller
    {

        private readonly ISessao _sessao;

        public Quem_SomosController(ISessao sessao)
        {
            _sessao = sessao;
        }

        public IActionResult Quem_Somos()
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
