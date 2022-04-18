using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;
        //private readonly ApplicationDbContext _applicationDbContext;
        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetAllAsync();

            return View(cinemas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")]Cinema model)
        {
            if (!ModelState.IsValid) return View(model);

            await _cinemaService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);

            if (cinema == null) return NotFound();

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cinema model)
        {
            model.ModifyDate = DateTime.Now;
            await _cinemaService.UpdateAsync(model.Id, model);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {            
            var cinema = await _cinemaService.GetByIdAsync(id);

            if (cinema == null) return NotFound();

            cinema.IsDelete = true;
            cinema.IsActive = false;
            cinema.ModifyDate = DateTime.Now;

            //await _cinemaService.DeleteAsync(id);
            await _cinemaService.UpdateAsync(id, cinema);

            return Ok();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);

            if (cinema == null) return NotFound();

            return View(cinema);
        }
    }
}
