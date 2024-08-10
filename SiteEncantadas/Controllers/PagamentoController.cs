using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteEncantadas.Business.QRCode;
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly Contexto _context;
        private readonly QrCodeService _qrCodeService;
        private readonly ISessao _sessao;

        public PagamentoController(QrCodeService qrCodeService, Contexto context, ISessao sessao)
        {
            _qrCodeService = qrCodeService;
            _context = context;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            Usuario usuario = _sessao.BuscarSessaoUsuario();
            if (usuario != null)
            {
                ViewBag.UsuarioLogado = true;
                ViewBag.Usuario = usuario;
            }
            else
            {
                ViewBag.UsuarioLogado = false;
            }
            return View(usuario);
            // TODO: AQUI VAI PRECISAR TER INJECAO DE DEPENDENCIA COM SESSAO PARA RETORNAR USUARIO LOGADO, COMO TEM NAS OUTRAS CONTROLLERES
            //double valorIngresso = 200.00;
            //var valorIngresso_json = JsonConvert.SerializeObject(valorIngresso);
            //return Json(valorIngresso_json);
        }

        public IActionResult CalcularValorTotal(int numero_deCadeiras)
        {
            double valorPorCadeira = 200.00;
            double valorToal = numero_deCadeiras * valorPorCadeira;
            var valorToal_json = JsonConvert.SerializeObject(valorToal);
          
            Usuario usuario = _sessao.BuscarSessaoUsuario();
            usuario.ValorApagar = valorToal;
            _sessao.AtualizarSessao(usuario);

            return Json(valorToal_json);
        }
        [HttpGet]
        public IActionResult GenerateQrCode(decimal amount)
        {
            var qrCodeImage = _qrCodeService.GenerateQrCode(amount);
            return File(qrCodeImage, "image/png");
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(decimal amount)
        {
            var payment = new Pagamento
            {
                Amount = amount,
                Status = "Pending",
                Date = DateTime.UtcNow
            };

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmPayment(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public IActionResult IrParaPagamento(double valorApagar)
        {
            return RedirectToAction("Index", "Pagamento");
        }

        [HttpPost]
        public IActionResult IndexPagamento()
        {
            return View();
        }

    }
}
