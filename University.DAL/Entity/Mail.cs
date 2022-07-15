using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DAL.Entity
{
    public class Mail
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

    }
}
