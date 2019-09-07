using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KFP.MODELS
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Enter your username")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter your Surname")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter your Contact Number ")]
        [Display(Name = "Contact Number")]
        public string ContactNO { get; set; }
        [Required(ErrorMessage = "Enter your Identity number ")]
        [Display(Name = "Identity number")]
        public string IdNo { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime DOB { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string ConfirmPasswoed { get; set; }
    }
}

