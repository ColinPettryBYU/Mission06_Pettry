// HomeController - handles all page routing for the Joel Hilton Film Collection app
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Pettry.Models;

namespace Mission06_Pettry.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        // Constructor with dependency injection for the database context
        public HomeController(MovieContext context)
        {
            _context = context;
        }

        // GET: Home page - displays the collection title and Joel's photo
        public IActionResult Index()
        {
            return View();
        }

        // GET: Get to Know Joel page - links to Quick Wits and Baconsale
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // GET: Movie Collection page - displays all movies in the database
        public IActionResult MovieCollection()
        {
            // Include the Category navigation property so we can display the category name
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
        }

        // GET: Add Movie form - displays the empty form for entering a new movie
        [HttpGet]
        public IActionResult AddMovie()
        {
            // Pass categories to the view for the dropdown menu
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View();
        }

        // POST: Add Movie form - receives the submitted form and saves to the database
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            // Check if the model is valid before saving
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                // Redirect to a confirmation message on the home page
                return View("Confirmation", movie);
            }
            else
            {
                // If validation fails, reload categories and return the form with errors
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();

                return View(movie);
            }
        }
    }
}
