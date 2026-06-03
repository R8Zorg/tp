using Microsoft.AspNetCore.Mvc;
using TP.Models;

namespace TP.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorViewModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorViewModel calculator)
        {
            if (!ModelState.IsValid)
                return View(calculator);

            ArgumentNullException.ThrowIfNull(calculator.FirstNumber);
            ArgumentNullException.ThrowIfNull(calculator.SecondNumber);

            if (calculator.Sign == '/' && calculator.SecondNumber == 0)
            {
                ModelState.AddModelError(nameof(calculator.SecondNumber),
                    "Division by zero is not allowed");

                return View(calculator);
            }

            calculator.Result = calculator.Sign switch
            {
                '+' => (float)(calculator.FirstNumber + calculator.SecondNumber),
                '-' => (float)(calculator.FirstNumber - calculator.SecondNumber),
                '*' => (float)(calculator.FirstNumber * calculator.SecondNumber),
                '/' => (float)(calculator.FirstNumber / calculator.SecondNumber),
                _ => 0
            };
            return View(calculator);
        }
    }
}
