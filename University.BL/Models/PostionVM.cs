using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Models
{
    public class PostionVM
    {
        public int id { get; set; }
        public string Name { get; set; }

        public int TrackId { get; set; }

        public Tracks Tracks { get; set; }
    }
}
