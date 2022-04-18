using ETicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class Producter: EntityBase
    {

        public string FullName { get; set; }

        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
