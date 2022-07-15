using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace University.DAL.Entity
{
    [Table("College")]
    public class College
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Expenses { get; set; }

        public ICollection<Stuff> stuff { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Courses> Courses { get; set; }
    }
}
