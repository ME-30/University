using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Interface
{
    public interface ITracksRep
    {
        IEnumerable<Tracks> GetAll();
        Tracks GetById(int id);
    }
}
