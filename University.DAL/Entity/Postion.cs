using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DAL.Entity
{
    [Table("Postion")]
    public class Postion
    {
        public int id { get; set; }
        public string Name { get; set; }

        public int TrackId { get; set; }
        [ForeignKey("TrackId")]

        public Tracks Tracks { get; set; }
        public ICollection<Stuff> Stuff { get; set; }
    }
}
