using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Nagarro.BookReading.Core.Entities
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter your username")]
        [Display(Name = "User Name")]
        public string userName { get; set; }


        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Please Provide a valid Password")]
        public string password { get; set; }
    }
}
