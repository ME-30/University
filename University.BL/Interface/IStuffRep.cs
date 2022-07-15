using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Interface
{
    public interface IStuffRep
    {
        IEnumerable<Stuff> Get();
        Stuff GetById(int id);
        IEnumerable<Stuff> SearchByName(string Name);

        Stuff Create(Stuff obj);
        Stuff Edit(Stuff obj);
        Stuff Delete(Stuff obj);
    }
}
