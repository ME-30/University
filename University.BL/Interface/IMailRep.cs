using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;

namespace University.BL.Interface
{
    public interface IMailRep
    {
       void  Create(Mail obj);
        IEnumerable<Mail> GetAll();
    }
}
