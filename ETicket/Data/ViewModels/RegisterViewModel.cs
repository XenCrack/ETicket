using System;
using System.ComponentModel.DataAnnotations;

namespace ETicket.Data.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="E-posta")]
        public string EmailAddress { get; set; }
        
        [Required]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreniz uyumsuz")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Ad, Soyad")]
        public string FullName { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
    }
}
