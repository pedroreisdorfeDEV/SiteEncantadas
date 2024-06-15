using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteEncantadas.Business.CadastroService;
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.ViewModels;

namespace WebEncantadas.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Contexto _context;
        private readonly ISessao _sessao;
        private readonly ICadastroService _cadastroService;

        public CadastroController(Contexto context, ISessao sessao, ICadastroService cadastroService)
        {
            _context = context;
            _sessao = sessao;
            _cadastroService = cadastroService;
        }

        public IActionResult Create()
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
            // Todo: aqui vou precisar mudar  a lógica, pq essa view espera retorno de Cadastroview model
            // TODO: comentário da antiga aplicação
            return View(usuario);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_(CadastroViewModel cadastro)
        {
            // retorno da View precisa ser revisto
            if (ModelState.IsValid)
            {
                bool emailJaExistente = await _cadastroService.VerificarEmailCadastro(cadastro.Email);

                if(emailJaExistente == false)
                {
                    _context.Add(cadastro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login");
                }
                else
                {
                    // mostrar popUp de email já cadastrado
                    return RedirectToAction("Login");
                }
            }
            return View(cadastro);
        }
    }
}
