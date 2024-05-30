using Microsoft.AspNetCore.Mvc;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Controllers
{
    public class ChaController : Controller
    {
        private readonly ISessao _sessao;

        public ChaController(ISessao sessao)
        {
            _sessao = sessao;
        }

        public IActionResult Cha()
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
