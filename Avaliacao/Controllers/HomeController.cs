using Avaliacao.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Avaliacao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa("Igor", 35, "igor@email.com"),
            new Pessoa("rayane", 25, "rayane@email.com"),
            new Pessoa("Alessandra", 40, "alessandra@email.com"),
            new Pessoa("Sebastião", 28, "sebastião@email.com")
        };
            List<Pessoa> model = pessoas.Where(p => p.Idade > 30).ToList();
            return View(model);
        }

        [HttpPost]
        public JsonResult CalculaFatorial(int valor)
        {
            BigInteger result = 1;

            if (valor == 0 || valor == 1)
            {
                result = 1;
                return Json(new { result, success = true });
            }

            for (int i = 2; i <= valor; i++)
            {
                result *= i;
            }

            return Json(new { result = result.ToString(), success = true });
        }
    }
}