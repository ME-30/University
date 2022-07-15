using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Interface;
using University.BL.Models;
using University.DAL.DataBase;
using University.DAL.Entity;

namespace University.BL.Repository
{
    public class CollegeRep : ICollegeRep
    {
        private readonly UniversityContext db; 


        public CollegeRep(UniversityContext db)
        {
            this.db = db;
        }

        public IEnumerable<College> Get()
        {
            var data = GetCollege();
            

            return data;
        }

        public College GetById(int id)
        {
            return GetCollegeById(id);
        }
         
        public void Create(College obj)
        {
         

            db.college.Add(obj);
            db.SaveChanges();
        }

        public void Edit(College obj)
        {
           db.Entry(obj).State = EntityState.Modified;

            db.SaveChanges();
        }

        public void Delete(College obj)
        {
           
            db.college.Remove(obj); 
            db.SaveChanges();

        }


        public IEnumerable<College> SearchByName(string Name)
        {
            var data = db.college.Include("College").Where(a => a.Name.Contains(Name));
            return data;
        }







        // Refactor
        private IEnumerable<College> GetCollege()
        {
            return db.college.Select(a => a);
        }

        private College GetCollegeById(int id)
        {
            return db.college.Where(a => a.Id == id).FirstOrDefault();
        }

    }
}
