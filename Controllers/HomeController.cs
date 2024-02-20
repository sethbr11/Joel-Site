using Microsoft.AspNetCore.Mvc;
using Mission06_Brock.Models;
using System.Diagnostics;

namespace Mission06_Brock.Controllers {
    public class HomeController : Controller {
        private MovieApplicationContext _context;

        public HomeController(MovieApplicationContext temp) { // Constructor
            _context = temp;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }
        [HttpGet]
        public IActionResult About() {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm() {
            ViewBag.categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(Movies response) {
            _context.Movies.Add(response); // Add the record to the database
            _context.SaveChanges(); // This makes the changes permanent (commits the changes)

            return View("MovieAppConfirmation", response);
        }
        [HttpGet]
        public IActionResult MovieCollection() {
            // Linq
            var applications = _context.Movies.ToList();
            return View(applications);
        }
    }
}
