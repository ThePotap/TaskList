using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskList.Models;

namespace TaskList.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TaskList()
        {
            var tasks = new List<Models.Task>()
            {
                new Models.Task{Description = "Уборка", Date = DateTime.Now.AddDays(1)},
                new Models.Task{Description = "Посуда", Date = DateTime.Now.AddDays(1)}
            };

            return View(tasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}