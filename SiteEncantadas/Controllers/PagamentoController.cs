using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SiteEncantadas.Controllers
{
    public class PagamentoController : Controller
    {
        public IActionResult Index()
        {
            // TODO: AQUI VAI PRECISAR TER INJECAO DE DEPENDENCIA COM SESSAO PARA RETORNAR USUARIO LOGADO, COMO TEM NAS OUTRAS CONTROLLERES
            double valorIngresso = 200.00;
            var valorIngresso_json = JsonConvert.SerializeObject(valorIngresso);
            return Json(valorIngresso_json);
        }

        public IActionResult CalcularValorTotal(int numero_deCadeiras)
        {
            double valorPorCadeira = 200.00;
            double valorToal = numero_deCadeiras * valorPorCadeira;
            var valorToal_json = JsonConvert.SerializeObject(valorToal);
            return Json(valorToal_json);
        }
    }
}
