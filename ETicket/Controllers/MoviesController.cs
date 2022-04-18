using ETicket.Data.Services;
using ETicket.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAllAsync(n=> n.Cinema);

            return View(movies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            var dropdown = await _service.GetMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(dropdown.Cinemas, "Id", "Name");
            ViewBag.Productors = new SelectList(dropdown.Producters, "Id", "Name");
            ViewBag.MovieTypes = new SelectList(dropdown.MovieTypes, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var dropdown = await _service.GetMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(dropdown.Cinemas, "Id", "Name");
                ViewBag.Productors = new SelectList(dropdown.Producters, "Id", "Name");
                ViewBag.MovieTypes = new SelectList(dropdown.MovieTypes, "Id", "Name");

                return View(model);
            }

            await _service.AddAsync(model);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);

            return View(movieDetail);
        }
    }
}
