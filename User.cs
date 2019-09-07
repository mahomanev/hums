using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFP.DATA
{
    public class User
    {
       
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string ContactNO { get; set; }
        public string IdNo { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        [Key]
        [Required]
        [Display(Name = "Email")]
        [DataType(dataType: DataType.EmailAddress)]
        //[RegularExpression(pattern: @"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$", ErrorMessage = "Email not valid")]
        public string Email { get; set; }

        public string Password { get; set; }
      
    }
   
    public class Client : User
    {

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
    public class Instructor : User
    {
        //public virtual ICollection<Klass> Klass { get; set; }
    }
}
