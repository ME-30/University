using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Interface
{
    public interface IPostionsRep
    {
        IEnumerable<Postion> GetAll(Expression<Func<Postion, bool>> filter = null);
        Postion GetById(int id);
    }
}
