using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public CadastroController(Contexto context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
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
            // Todo: aqui vou precisar mudar  a lógica, pq essa view espera retorno de Cadastroview model
            // TODO: comentário da antiga aplicação
            return View(usuario);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_([Bind("id, NomeResponsavel,CPF,Email,ConfirmacaoEmail,Contato,ContatoEmergencial,NomeCrianca_1,IdadeCrianca_1,DataDeNascimento_1,RestricaoAlimentar_1,NomeCrianca_2,IdadeCrianca_2,DataDeNascimento_2,RestricaoAlimentar_2,NomeCrianca_3,IdadeCrianca_3,DataDeNascimento_3,RestricaoAlimentar_3,NomeCrianca_4,IdadeCrianca_4,DataDeNascimento_4,RestricaoAlimentar_4, Senha")] CadastroViewModel cadastro)
        {
            // retorno da View precisa ser revisto
            if (ModelState.IsValid)
            {

                _context.Add(cadastro);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }
            return View(cadastro);
        }
    }
}
