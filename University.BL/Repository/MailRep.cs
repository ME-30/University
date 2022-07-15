using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Interface;
using University.DAL.DataBase;
using University.DAL.Entity;

namespace University.BL.Repository
{
    public class MailRep : IMailRep
    {
        private readonly UniversityContext db;

        public MailRep(UniversityContext db)
        {
            this.db = db;
        }
        public void Create(Mail obj)
        {

            db.Mail.Add(obj);
            db.SaveChanges();
        }

        public IEnumerable<Mail> GetAll()
        {
            var data = db.Mail.Select(a => a);

            return data;
        }
    }
}
