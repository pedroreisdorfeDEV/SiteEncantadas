using Microsoft.AspNetCore.Mvc;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Controllers
{
    public class FotosVideosController : Controller
    {
        private readonly ISessao _sessao;

        public FotosVideosController(ISessao sessao)
        {
            _sessao = sessao;
        }

        public IActionResult FotosVideos()
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
