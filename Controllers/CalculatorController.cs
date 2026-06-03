using Microsoft.AspNetCore.Mvc;
using TP.Models;

namespace TP.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorViewModel calculator)
        {
            return View();
        }
    }
}
