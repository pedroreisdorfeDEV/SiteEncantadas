using Microsoft.AspNetCore.Mvc;
using SiteEncantadas.Business.LoginService;
using SiteEncantadas.Data.Connections;
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.ViewModels;

namespace SiteEncantadas.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto _context;

        private readonly ISessao _sessao;
        private readonly ILoginService _loginService;
        private readonly ConnectionManager _connection = new ConnectionManager();

        public LoginController(Contexto context, ISessao sessao, ILoginService loginService)
        {
            _context = context;
            _sessao = sessao;
            _loginService = loginService;
        }
        public IActionResult Login()
        {
            //se usuário estiver logado, redirecionar para a home
            if (_sessao.BuscarSessaoUsuario() != null)
            {
                // TODO: mas quando entra nessa situação aqui, preciso trocar logar para botão sair
                ViewBag.UsuarioLogado = true;

                return RedirectToAction("Index", "Home");
            }
            ViewBag.UsuarioLogado = false;
            return View();
        }

        public IActionResult SairSessaoUsuario()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logar(string login, string senha)
        {
            // retorno da View precisa ser revisto
            if (ModelState.IsValid)
            {
                Usuario usuario = await _loginService.ValidarUsuario(login, senha);

                _sessao.CriarSessaoUsuario(usuario);

                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }
    }
}
