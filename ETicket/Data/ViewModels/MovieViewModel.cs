using ETicket.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ETicket.Data.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        
        [Display(Name ="Ad")]
        [Required(ErrorMessage = "Film adı boş bırakılamaz")]
        public string Name { get; set; }

        [Display(Name ="Konu")]
        [Required(ErrorMessage = "Film konusu boş bırakılamaz")]
        public string Description { get; set; }

        [Display (Name ="Ücret")]
        [Required (ErrorMessage ="Ücret alanı boş bırakılamaz")]
        public double Price { get; set; }

        [Display(Name = "Afiş")]
        [Required(ErrorMessage ="Afiş eklemelisiniz")]
        public string ImageUrl { get; set; }

        [Display(Name = "Film Türü")]
        [Required(ErrorMessage = "Tür seçmelisiniz")]
        public int TypeId { get; set; }

        [Display(Name = "Vizyon Başlangıç Tarihi")]
        [Required(ErrorMessage = "Vizyon başlanıç tarihini seçmelisiniz")]
        public DateTime StartDate { get; set; }
        
        [Display(Name = "Vizyon Bitiş Tarihi")]
        [Required(ErrorMessage = "Vizyon bitiş tarihini seçmelisiniz")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Sinema")]
        [Required(ErrorMessage = "Sinema seçmelisiniz")]
        public int CinemaId { get; set; }
        
        [Display(Name = "Yapımcı")]
        [Required(ErrorMessage = "Yapımcı seçmelisiniz")]
        public int ProductorId { get; set; }

    }
}
