using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Models
{
   public class CoursesVM
    {
        public int id{ get; set; }


        [Required(ErrorMessage = "Name Course Require")]
        public string CourseName { get; set; }

        //[Required(ErrorMessage = "Name Material Require")]
        public string MaterialName { get; set; }
        public IFormFile MaterialUrl { get; set; }
        public string ExamName { get; set; }
        public IFormFile ExamUrl { get; set; }
        public int CollegeId { get; set; }

        public College College { get; set; }
    }
}
