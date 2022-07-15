using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DAL.Entity
{
    public class Courses
    {
        public int id { get; set; }
        public string CourseName { get; set; }
        public string MaterialName { get; set; }
        public string ExamName { get; set; }


        public int CollegeId { get; set; }

        [ForeignKey("CollegeId")]
        public College College { get; set; }
    }
}
