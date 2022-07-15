using Microsoft.EntityFrameworkCore;
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
    public class StuffRep : IStuffRep
    {
        private readonly UniversityContext db;

        public StuffRep(UniversityContext db)
        {
            this.db = db;
        }
        public IEnumerable<Stuff> Get()
        {
            var data = db.Stuff.Include("College").Select(a => a);
            return data;
        }

        public Stuff Create(Stuff obj)
        {
            var data = db.Stuff.Add(obj);
            db.SaveChanges();
            return db.Stuff.OrderBy(a => a.Id).LastOrDefault();
        }

       
        public Stuff Edit(Stuff obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return db.Stuff.Find(obj.Id);
        }

        public Stuff GetById(int id)
        {
            var data = db.Stuff.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
        public Stuff Delete(Stuff obj)
        {
            db.Stuff.Remove(obj);
            db.SaveChanges();

            return db.Stuff.Find(obj.Id);
        }

        public IEnumerable<Stuff> SearchByName(string Name)
        {
            var data = db.Stuff.Include("College").Where(a => a.Name.Contains(Name));
            return data;
        }

       
    }
}
