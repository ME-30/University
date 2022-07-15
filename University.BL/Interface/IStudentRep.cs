using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Interface
{
    public interface IStudentRep
    {
        IEnumerable<Student> Get();
        Student GetById(int id);
        IEnumerable<Student> SearchByName(string Name);

        Student Create(Student obj);
        Student Edit(Student obj);
        Student Delete(Student obj);

    }
}
