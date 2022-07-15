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
    public class CoursesRep : ICoursesRep
    {
        private readonly UniversityContext db;

        public CoursesRep(UniversityContext db)
        {
            this.db = db;
        }
        public IEnumerable<Courses> Get()
        {
            var data = db.Courses.Include("College").Select(a => a);
            return data;
        }

        public Courses Create(Courses obj)
        {
            var data = db.Courses.Add(obj);
            db.SaveChanges();
            return db.Courses.OrderBy(a => a.id).LastOrDefault();
        }


        public Courses Edit(Courses obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return db.Courses.Find(obj.id);
        }

        public Courses GetById(int id)
        {
            var data = db.Courses.Where(a => a.id == id).FirstOrDefault();
            return data;
        }
        public Courses Delete(Courses obj)
        {
            db.Courses.Remove(obj);
            db.SaveChanges();

            return db.Courses.Find(obj.id);
        }

        public IEnumerable<Courses> SearchByName(string CourseName)
        {
            var data = db.Courses.Include("College").Where(a => a.CourseName.Contains(CourseName));
            return data;
        }

    }
}
