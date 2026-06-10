using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using TP_WebApp.Models;

namespace TP_WebApp.Controllers
{
	public class HomeController : Controller
	{
		private float number = 100f;
		[HttpGet]
		public ActionResult Index()
		{
			ViewBag.Number = number;
			return View(new CalculatorModel());
		}

		[HttpPost]
		public ActionResult Index(CalculatorModel calc, string sign, string buttonAction)
		{
			ViewBag.Number = number;
			if (!ModelState.IsValid)
			{
				return View(calc);
			}

			if (buttonAction.Equals("clear"))
			{
				ModelState.Clear();
				return View(new CalculatorModel());
			}

			if (sign.IsEmpty())
			{
				return View(calc);
			}

			calc.Sign = sign;
			switch (calc.Sign)
			{
				case "+":
					calc.Result = (ulong)calc.FirstNumber + calc.SecondNumber;
					break;
				case "-":
					calc.Result = (ulong)calc.FirstNumber - calc.SecondNumber;
					break;
				case "*":
					calc.Result = (ulong)calc.FirstNumber * calc.SecondNumber;
					break;
				case "/":
					calc.Result = (ulong)calc.FirstNumber / calc.SecondNumber;
					break;

			}
			HttpCookie cookie = new HttpCookie("LastOperation");
			cookie["Result"] = $"{calc.FirstNumber} {calc.Sign} {calc.SecondNumber} = {calc.Result}";
			cookie.Expires = DateTime.Now.AddDays(1);
			Response.Cookies.Add(cookie);

			return View(calc);
		}

		public ActionResult Result()
		{
			return View();
		}
	}
}