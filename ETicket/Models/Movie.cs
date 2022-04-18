using ETicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class Movie: EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CinemaId { get; set; }
        public int MovieTypeId { get; set; }
        public int ProducterId { get; set; }

        [ForeignKey(nameof(CinemaId))]
        public Cinema Cinema { get; set; }

        [ForeignKey(nameof(MovieTypeId))]
        public MovieType MovieType { get; set; }

        [ForeignKey(nameof(ProducterId))]
        public Producter Producter { get; set; }

    }
}
