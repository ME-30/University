using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Interface
{
    public interface ICoursesRep
    {
        IEnumerable<Courses> Get();
        Courses GetById(int id);
        IEnumerable<Courses> SearchByName(string Name);

        Courses Create(Courses obj);
        Courses Edit(Courses obj);
        Courses Delete(Courses obj);
    }
}
