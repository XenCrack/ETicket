using System.ComponentModel.DataAnnotations;

namespace ETicket.Data.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="E-posta")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Şifre")]
        public string Password { get; set; }
    }
}
