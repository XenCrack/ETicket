using ETicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class Cinema: EntityBase
    {

        [Display(Name = "Adı")]
        [Required(ErrorMessage = "Sinema adı boş bırakılamaz")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama boş bırakılamaz")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Logo boş bırakılamaz")]
        [Display(Name = "Logo")]
        public string Logo { get; set; }

        //Relationship
        public List<Movie> Movies { get; set; }       
    }
}
