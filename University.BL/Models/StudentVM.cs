using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Models
{
    public class StudentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Require HareDate")]
        public DateTime HareDate { get; set; }
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "Require Notes")]
        public string Notes { get; set; }

        [EmailAddress(ErrorMessage = "Email Invaled")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Require Address")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Chouse College")]
        public int CollegeId { get; set; }

        public College College { get; set; }
    }
}
