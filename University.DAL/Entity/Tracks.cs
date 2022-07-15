using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DAL.Entity
{
    [Table("Track")]
    public class Tracks
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public ICollection<Postion> Postion { get; set; }


    }
}
