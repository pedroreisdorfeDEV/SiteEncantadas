using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteEncantadas.Business.CadastroService;
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.ViewModels;
using System.Diagnostics;

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

        public IActionResult Cadastro()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_(CadastroViewModel cadastro)
        {
            // precisa de tratamento de erro ao se cadastrar

            bool emailJaExistente = await _cadastroService.VerificarEmailCadastro(cadastro.Email);

            if (emailJaExistente == false)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                Usuario usuario = null;
                return View("Cadastro", usuario);
            }
            else { 
              
                // tratar mensagem e modal no front
                Usuario usuario = null;
                ViewBag.ErrorMessage = "Email já cadastrado!";
                return BadRequest("Email já existente");
                //return RedirectToAction("Index", "Home");
            }

        }
    }
}
