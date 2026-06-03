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
        public IActionResult Index(CalculatorViewModel calculator, string action)
        {
            if (action.Equals("clear"))
            {
                ModelState.Clear();
                return View(new CalculatorViewModel());
            }

            if (!ModelState.IsValid)
            {
                return View(calculator);
            }
            if (calculator.FirstNumber == 0)
            {
                ModelState.AddModelError(nameof(calculator.FirstNumber), "Number cannot be 0. (Ya tak zahotel)");
            }

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
            ViewBag.ExpectedResult = 100;
            ViewBag.Message = calculator.Result == (float)ViewBag.ExpectedResult
                ? "Result matches expected value"
                : "Result doesn't match expected value";

            string expression = $"{calculator.FirstNumber} {calculator.Sign} {calculator.SecondNumber} = {calculator.Result}";
            Response.Cookies.Append(
                    "LastOperation",
                    expression,
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddHours(1)
                    }
                    );

            return View(calculator);
        }

        public IActionResult History()
        {
            string? expression = Request.Cookies["LastOperation"];

            if (!string.IsNullOrEmpty(expression))
            {
                int pos;
                if ((pos = expression.IndexOf('+')) >= 0)
                {
                    expression = expression.Remove(pos, 1);
                    expression = expression.Insert(pos, "plus");
                }
                else if ((pos = expression.IndexOf('-')) >= 0)
                {
                    expression = expression.Remove(pos, 1);
                    expression = expression.Insert(pos, "minus");
                }
                else if ((pos = expression.IndexOf('*')) >= 0)
                {
                    expression = expression.Remove(pos, 1);
                    expression = expression.Insert(pos, "multiplied by");
                }
                else if ((pos = expression.IndexOf('/')) >= 0)
                {
                    expression = expression.Remove(pos, 1);
                    expression = expression.Insert(pos, "divided by");
                }
            }


            ViewBag.Expression = expression;

            return View();
        }
    }
}
