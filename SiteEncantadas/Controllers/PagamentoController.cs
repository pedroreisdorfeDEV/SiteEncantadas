using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteEncantadas.Business.QRCode;
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Helper.Session;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.Entities.Reserva;

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

            if (usuario != null){
                usuario.ValorApagar = valorToal;
                _sessao.AtualizarSessao(usuario);
            }

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
        public async Task ConfirmPayment()
        {
            Usuario usuario = _sessao.BuscarSessaoUsuario();

        }

        [HttpPost]
        public IActionResult IrParaPagamento([FromBody] ReservaDTO reservaDTO)
        {
            Usuario usuario = _sessao.BuscarSessaoUsuario();
           
            foreach (var reserva in reservaDTO.ListaReserva)
            {
                Reserva_ingressos reserva_Ingresso = new Reserva_ingressos();

                if(reserva <= 8)
                {
                    reserva_Ingresso.num_mesa = 1;
                }
                else if(reserva > 8 && reserva <= 16)
                {
                    reserva_Ingresso.num_mesa = 2;
                }
                else if(reserva > 16 && reserva <= 24)
                {
                    reserva_Ingresso.num_mesa = 3;
                }
                else
                {
                    reserva_Ingresso.num_mesa = 4;
                }
                reserva_Ingresso.num_cadeira = reserva;
                reserva_Ingresso.ID = reserva;
                reserva_Ingresso.valor_cadeira = 200.0m;
                usuario.ListaReservas.Add(reserva_Ingresso);

            }
            _sessao.AtualizarSessao(usuario);
            return RedirectToAction("Index", "Pagamento");
        }

        [HttpPost]
        public IActionResult IndexPagamento()
        {
            return View();
        }

    }
}
