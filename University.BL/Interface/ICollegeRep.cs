using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.DAL.Entity;

namespace University.BL.Interface
{
    public interface ICollegeRep
    {
        IEnumerable<College> Get();
        College GetById(int id);
        IEnumerable<College> SearchByName(string Name);

        void Create(College obj);
        void Edit(College obj);
        void Delete(College obj);
    }
}
