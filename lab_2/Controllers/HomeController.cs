using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_WebApp2.Models;

namespace TP_WebApp2.Controllers
{
    public class HomeController : Controller
    {
        private static List<OrderViewModel> orders = new List<OrderViewModel>
		{
			new OrderViewModel
			{
				Id = 0,
				EventType = "Party",
				EventDate = DateTime.Now.AddDays(2),
				EventDuration = TimeSpan.FromHours(10),
				Price = 12500,
				Status = "Waiting",
				ChildrenCount = 0,
				CustomerEmail = null,
			},
			new OrderViewModel
			{
				Id = 1,
				EventType = "Ne party",
				EventDate = DateTime.Now.AddDays(5),
				EventDuration = TimeSpan.FromHours(24),
				Price = 99999,
				Status = "Waiting",
				ChildrenCount = 15,
				CustomerEmail = "ustavshaya_sobaka@babaka.gav",
			}
		};

		[HttpGet]
        public ActionResult Index()
        {
			ViewData["UseInnerMethod"] = true;
			return View(orders);
        }

		[HttpPost]
		public ActionResult Index(string btnDelete)
		{
			var order = orders.FirstOrDefault(x => x.Id == Int32.Parse(btnDelete));
			if (order != null)
			{
				orders.Remove(order);
			}

			return RedirectToAction("Index");
		}

		[HttpGet]
        public ActionResult Edit(int id)
        {
			var order = orders.FirstOrDefault(x => x.Id == id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}

		[HttpPost]
		public ActionResult Edit (OrderViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var order = orders.FirstOrDefault(x => x.Id == model.Id);
			if (order == null)
			{
				return HttpNotFound();
			}

			order.Id = model.Id;
			order.EventType = model.EventType;
			order.EventDate = model.EventDate;
			order.EventDuration = model.EventDuration;
			order.Price = model.Price;
			order.Status = model.Status;
			order.ChildrenCount = model.ChildrenCount;
			order.CustomerEmail = model.CustomerEmail;

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(OrderViewModel model)
		{
			model.Id = orders.Count > 0
				? orders.Max(x => x.Id) + 1
				: 1;
			orders.Add(model);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Details(int id)
		{
			var order = orders.FirstOrDefault(x => x.Id == id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}
	}
}