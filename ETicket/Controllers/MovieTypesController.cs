using ETicket.Data.Services;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieTypesController : Controller
    {
        private readonly IMovieTypeService _service;

        public MovieTypesController(IMovieTypeService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var movieTypes = await _service.GetAllAsync();

            return View(movieTypes);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieType model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.IsDelete = false;
            model.IsActive = true;
            model.CreateDate = System.DateTime.Now;

            await _service.AddAsync(model);

            return RedirectToAction("Index");

        }
    }
}
