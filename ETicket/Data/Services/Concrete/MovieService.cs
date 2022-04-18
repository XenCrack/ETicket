using ETicket.Data.Base;
using ETicket.Data.ViewModels;
using ETicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Services.Concrete
{
    public class MovieService: EntityBaseRepository<Movie>, IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context): base (context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <example>
        /// var obj = _service.AddAsync(model)
        /// </example>
        /// <see cref=""/>
        /// <![CDATA[]]>
        public async Task AddAsync(MovieViewModel model)
        {
            var movie = new Movie()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CinemaId = model.CinemaId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                MovieTypeId = model.TypeId,
                ProducterId = model.ProductorId
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var result = await 
                _context
                .Movies
                .Include(c=> c.Cinema)
                .Include(p=> p.Producter)
                .Include(mt=> mt.MovieType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<MovieDropdownViewModel> GetMovieDropdownValues()
        {
            var response = new MovieDropdownViewModel()
            {
                Cinemas = await _context.Cinemas.OrderBy(x => x.Name).ToListAsync(),
                MovieTypes = await _context.MovieTypes.OrderBy(x => x.Name).ToListAsync(),
                Producters = await _context.Producters.OrderBy(x => x.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateAsync(MovieViewModel model)
        {
            //var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == model.Id);
            var movie = await (from m in _context.Movies where m.Id == model.Id select m).FirstOrDefaultAsync();

            if (movie != null)
            {
                movie.Name = model.Name;
                movie.Description = model.Description;
                movie.Price = model.Price;
                movie.ImageUrl = model.ImageUrl;
                movie.CinemaId = model.CinemaId;
                movie.StartDate = model.StartDate;
                movie.EndDate = model.EndDate;
                movie.MovieTypeId = model.TypeId;
                movie.ProducterId = model.ProductorId;

                await _context.SaveChangesAsync();
            }
        }
    }
}
