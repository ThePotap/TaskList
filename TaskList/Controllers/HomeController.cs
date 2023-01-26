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
            Tasks.Add(new Models.Task { Id = Tasks.Count + 1, Description = "Уборка", ExpectedDate = DateTime.Now.AddDays(1) });
            Tasks.Add(new Models.Task { Id = Tasks.Count + 1, Description = "Посуда", ExpectedDate = DateTime.Now.AddDays(1) });

            return View(Tasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult DeleteTask(string delete)
        {
            var id = Int32.Parse(delete);
            var found = Tasks.Find(item => item.Id == id);
            if (found != null)
            {
                Tasks.Remove(found);
            }
            return View("TaskList", Tasks);
        }

        [HttpPost]
        public IActionResult AddTask()
        {
            var task = new Models.Task();
            return View("TaskCard", task);
        }

        [HttpPost]
        public IActionResult CardAddEdit(Models.Task task)
        {
            if(task.Id == 0)
            {
                task.Id = Tasks.Count + 1;
                Tasks.Add(task);
            }
            else
            {
                var found = Tasks.Find(item => item.Id == task.Id);
                if (found != null)
                {
                    Tasks.Remove(found);
                    Tasks.Add(task);
                }
            }
            
            return View("TaskList", Tasks);
        }

        [HttpPost]
        public IActionResult CardCancel()
        {
            return View("TaskList", Tasks);
        }
    }
}