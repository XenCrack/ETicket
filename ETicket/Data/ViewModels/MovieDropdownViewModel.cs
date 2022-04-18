using ETicket.Models;
using System.Collections.Generic;

namespace ETicket.Data.ViewModels
{
    public class MovieDropdownViewModel
    {

        public MovieDropdownViewModel()
        {
            Producters = new List<Producter>();
            Cinemas = new List<Cinema>();
            MovieTypes = new List<MovieType>();
        }

        public List<Producter> Producters { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<MovieType> MovieTypes { get; set; }
    }
}
