using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Models
{
    public class StuffVM
    {
        public StuffVM()
        {
            CreationDate = DateTime.Now;
        }
        public int Id { get; set; }


        [Required(ErrorMessage = "Name Require")]
        [StringLength(50, ErrorMessage = "Max Lenght = 50")]
        [MinLength(3, ErrorMessage = "Max Lenght = 3")]
        public string Name { get; set; }
        [Range(2000, 15000, ErrorMessage = "Range btw 2K:15k")]
        public string Salary { get; set; }
        public DateTime HareDate { get; set; }
        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }
        public string Notes { get; set; }
        [EmailAddress(ErrorMessage = "Mail Invalid")]
        public string Email { get; set; }
        //[RegularExpression("[0-9{2,5] -[a - zA - Z]{2,5}-[a - zA - Z]{2,5}-[a - zA - Z]{2,5}",ErrorMessage ="Like : 12Street-City-Country")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Chouse College")]

        public int CollegeId { get; set; }

        public College College { get; set; }
        // public int PostionId { get; set; }

        //public Postion Postion { get; set; }

    }
}
