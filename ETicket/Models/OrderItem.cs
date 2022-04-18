using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int MovieId { get; set; }

        public int OrderId { get; set; }

        
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
