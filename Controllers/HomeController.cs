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
        public IActionResult MovieCollection() {
            return View();
        }
        [HttpPost]
        public IActionResult MovieCollection(MovieApplication response) {
            _context.Applications.Add(response); // Add the record to the database
            _context.SaveChanges(); // This makes the changes permanent (commits the changes)

            // NOTE: THIS DOES NOT HANDLE INVALID INPUTS YET! Will need to implement try/catch

            return View("MovieAppConfirmation", response);
        }
    }
}
