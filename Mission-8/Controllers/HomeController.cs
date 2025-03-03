using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission_8.Models;

namespace Mission_8.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult Quadrants()
        {
            var tasks = _dbContext.Tasks
            .Where(t => !t.Completed) // Only show incomplete tasks
            .ToList();

            // Log task data to ensure they're being fetched
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task.TaskName}, Quadrant: {task.Quadrant}");
            }
            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddEditTask(int? id)
        {
            // Load categories for the dropdown
            ViewBag.Categories = _dbContext.Categories
                .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.CategoryName })
            .ToList();

            if (id.HasValue)
            {
                var task = _dbContext.Tasks.Find(id.Value);
                if (task == null)
                {
                    return NotFound();
                }
                return View(task);
            }

            return View(new TaskModel());
        }

        [HttpPost]
        public IActionResult AddEditTask(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskId == 0)
                {
    
                }
                else
                {
                    _dbContext.Tasks.Update(task); // Update existing task
                }


            }
            _dbContext.Tasks.Add(task); // Add new task
            _dbContext.SaveChanges();
            return RedirectToAction("Confirmation"); // Redirect after save

            //// Reload categories if validation fails
            //ViewBag.Categories = _dbContext.Categories
            //    .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.CategoryName })
            //    .ToList();

            //return View(task);
        }

    }
}
