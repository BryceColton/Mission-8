using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission_8.Models;

namespace Mission_8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Home page
        }
        public IActionResult Quadrants()
        {
            return View(); // Quadrants View
        }

        [HttpGet]
        public IActionResult AddEditTask(int? id)
        {
            if (id.HasValue)
            {
                return View();
            }
            return View();
        }

        [HttpPost]

        public IActionResult AddEditTask(Task task)
        {
            return View();
        }

        
    }
}
