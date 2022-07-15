using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using University.BL.Interface;
using University.DAL.DataBase;
using University.DAL.Entity;

namespace University.BL.Repository
{
    public class PostionsRep : IPostionsRep
    {
        private readonly UniversityContext db;

        public PostionsRep(UniversityContext db)
        {
            this.db = db;
        }
       

        public IEnumerable<Postion> GetAll(Expression<Func<Postion, bool>> filter = null)
        {
                if(filter == null)
            {
                var data = db.Postion.Select(a => a);

                return data;
            }
            else
            {
                return db.Postion.Where(filter);
            }
        }

        public Postion GetById(int id)
        {
            var data = db.Postion.Where(a => a.id == id).FirstOrDefault();
            return data;
        }

        
    }
}
