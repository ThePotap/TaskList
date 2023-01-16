using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskList.Models;

namespace TaskList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Models.Task> Tasks { get; set; }

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
            Tasks = new List<Models.Task>();
            Tasks.Add(new Models.Task { Id = 1, Description = "Уборка", ExpectedDate = DateTime.Now.AddDays(1) });
            Tasks.Add(new Models.Task { Id = 2, Description = "Посуда", ExpectedDate = DateTime.Now.AddDays(1) });

            return View(Tasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult DeleteTask(string deleteId)
        {
            var id = Int32.Parse(deleteId);
            var found = Tasks.Find(item => item.Id == id);
            if(found != null)
            {
                Tasks.Remove(found);
            }
            return View(Tasks);
        }
    }
}