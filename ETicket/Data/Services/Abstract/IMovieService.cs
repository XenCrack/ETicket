using ETicket.Data.Base;
using ETicket.Data.ViewModels;
using ETicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task AddAsync(MovieViewModel model);
        Task UpdateAsync(MovieViewModel model);
        Task<MovieDropdownViewModel> GetMovieDropdownValues();
    }
}
