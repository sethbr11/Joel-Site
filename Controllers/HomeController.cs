using Microsoft.AspNetCore.Mvc;
using Mission06_Brock.Models;
using System.Diagnostics;

namespace Mission06_Brock.Controllers {
    public class HomeController : Controller {
        private MovieApplicationContext _context;

        public HomeController(MovieApplicationContext temp) { // Constructor
            _context = temp;
        }

        [HttpGet] public IActionResult Index() { return View(); } // Home page

        [HttpGet] public IActionResult About() { return View(); } // About page

        [HttpGet]
        public IActionResult MovieForm() { // Go to form to submit movie recommendations
            // Get all of the options for the different categories
            ViewBag.categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

            return View(new Movie());
        }
        [HttpPost]
        public IActionResult MovieForm(Movie response) { // Add the movie recommendation to table
            if (ModelState.IsValid) {
                _context.Movies.Add(response); // Add the record to the database
                _context.SaveChanges(); // This makes the changes permanent (commits the changes)

                return View("MovieAppConfirmation", response); // Go to confirmation screen
            }
            else { // For invalid responses, send them back to change their responses
                ViewBag.categories = _context.Categories
                    .OrderBy(x => x.Category)
                    .ToList();

                return View(response); 
            } 
        }

        [HttpGet]
        public IActionResult MovieCollection() { // Go to table that shows the movie list
            var applications = _context.Movies.ToList(); // Linq -- get our data to pass on

            return View(applications);
        }

        [HttpGet]
        public IActionResult EditMovie(int movieId) { // Go to our movie recommendation form, but this time to edit an existing entry
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == movieId); // This is like .Where but returns just one record instead of a list

            // Get all of the options for the different categories
            ViewBag.categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

            return View("MovieForm", recordToEdit);
        }
        [HttpPost]
        public IActionResult EditMovie(Movie app) { // Save the changes of our edit
            // THIS IS NOT WORKING, FIX!!
            if (ModelState.IsValid) { // Update the record 
                _context.Update(app);
                _context.SaveChanges();

                return RedirectToAction("MovieCollection");
            }
            else {
                // Get all of the options for the different categories
                ViewBag.categories = _context.Categories
                    .OrderBy(x => x.Category)
                    .ToList();

                return View("MovieForm", app);
            }
        }

        [HttpGet]
        public IActionResult DeleteMovie(int movieId) {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == movieId);

            return View(recordToDelete); 
        }
        [HttpPost]
        public IActionResult DeleteMovie(Movie app) {
            // Delete the record
            _context.Movies.Remove(app);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }
    }
}
