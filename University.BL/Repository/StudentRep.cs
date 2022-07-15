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
    public class StudentRep  : IStudentRep
    {
        private readonly UniversityContext db;

        public StudentRep(UniversityContext db)
        {
            this.db = db;
        }
        public IEnumerable<Student> Get()
        {
            var data = db.Student.Include("College").Select(a => a);
            return data;
        }

        public Student Create(Student obj)
        {
            var data = db.Student.Add(obj);
            db.SaveChanges();
            return db.Student.OrderBy(a => a.Id).LastOrDefault();
        }


        public Student Edit(Student obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return db.Student.Find(obj.Id);
        }

        public Student GetById(int id)
        {
            var data = db.Student.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
        public Student Delete(Student obj)
        {
            db.Student.Remove(obj);
            db.SaveChanges();

            return db.Student.Find(obj.Id);
        }

        public IEnumerable<Student> SearchByName(string Name)
        {
            var data = db.Student.Include("College").Where(a => a.Name.Contains(Name));
            return data;
        }


    }
}
