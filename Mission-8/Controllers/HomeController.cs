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
                    _dbContext.Tasks.Add(task); // Add new task
                }
                else
                {
                    _dbContext.Tasks.Update(task); // Update existing task
                }

                _dbContext.SaveChanges();
                return RedirectToAction("Quadrants"); // Redirect after save
            }

            // Reload categories if validation fails
            ViewBag.Categories = _dbContext.Categories
                .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.CategoryName })
                .ToList();

            return View(task);
        }


    }
}
