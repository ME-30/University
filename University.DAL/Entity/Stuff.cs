using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DAL.Entity
{
    [Table("Stuff")]

    public class Stuff
    {
         [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Salary { get; set; }
        public DateTime HareDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public int CollegeId { get; set; }

        [ForeignKey("CollegeId")]
        public College College { get; set; }
        //public int PostionId { get; set; }
        //[ForeignKey("PostionId")]
        //public Postion Postion { get; set; }

    }
}
