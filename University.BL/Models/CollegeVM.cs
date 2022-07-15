using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.Models
{
    public class CollegeVM
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Name Require")]
        [StringLength(50 , ErrorMessage ="Max Lenght = 50")]
        [MinLength(3 , ErrorMessage ="Max Lenght = 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code Require")]
        [StringLength(50, ErrorMessage = "Max Lenght = 50")]
        [MinLength(3, ErrorMessage = "Max Lenght = 3")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Expenses Require")]
        public string Expenses { get; set; }
        
    }
}
