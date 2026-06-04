using Microsoft.AspNetCore.Mvc;
using lab_2.Models;

namespace lab_2.Controllers
{
    public class OrderController : Controller
    {
        private static List<OrderViewModel> orders = new()
        {
            new OrderViewModel
            {
                Id = 1,
                EventType = "Birthday",
                EventDate = DateTime.Now.AddDays(7),
                EventDuration = TimeSpan.FromHours(3),
                Price = 1500,
                Status = "Created",
                ChildrenCount = 10,
                CustomerEmail = "test@mail.com"
            }
        };

        // Просмотр всех заказов
        public IActionResult Index()
        {
            return View(orders);
        }

        // Просмотр одного заказа
        public IActionResult Details(int id)
        {
            var order = orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // Форма добавления
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Добавление
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = orders.Count > 0
                ? orders.Max(x => x.Id) + 1
                : 1;

            orders.Add(model);

            return RedirectToAction(nameof(Index));
        }

        // Форма редактирования
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // Редактирование
        [HttpPost]
        public IActionResult Edit(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var order = orders.FirstOrDefault(x => x.Id == model.Id);

            if (order == null)
                return NotFound();

            order.EventType = model.EventType;
            order.EventDate = model.EventDate;
            order.EventDuration = model.EventDuration;
            order.Price = model.Price;
            order.Status = model.Status;
            order.ChildrenCount = model.ChildrenCount;
            order.CustomerEmail = model.CustomerEmail;

            return RedirectToAction(nameof(Index));
        }
    }
}
