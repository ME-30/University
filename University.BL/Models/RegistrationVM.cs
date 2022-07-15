using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace University.BL.Models
{
    public class RegistrationVM
    {

        [Required(ErrorMessage = "This Field Required")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6,ErrorMessage = "Min Len 6")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        [Compare("Password",ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }

    }
}
