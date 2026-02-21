// HomeController - handles all page routing and CRUD operations for the movie collection
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
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("MovieCollection");
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

        // GET: Edit Movie form - loads the movie data into the form for editing
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            // Find the movie by its ID
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            // Pass categories to the view for the dropdown menu
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(movie);
        }

        // POST: Edit Movie form - updates the movie record in the database
        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();

                return RedirectToAction("MovieCollection");
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

        // GET: Delete Movie confirmation page - shows movie details before deleting
        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            // Find the movie by its ID and include Category for display
            var movie = _context.Movies
                .Include(m => m.Category)
                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Delete Movie - removes the movie from the database
        [HttpPost]
        public IActionResult DeleteConfirmed(int movieId)
        {
            var movie = _context.Movies.Find(movieId);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieCollection");
        }
    }
}
