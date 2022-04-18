using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ETicket.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Display(Name ="Soyad")]
        public string Surname { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDate { get; set; }

        public string Discriminator { get; set; }
    }
}
