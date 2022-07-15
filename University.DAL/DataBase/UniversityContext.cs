using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Entity;
using University.DAL.Extend;

namespace University.DAL.DataBase
{
    public class UniversityContext : IdentityDbContext<ApplicationUser>
    {
        public UniversityContext(DbContextOptions<UniversityContext> opt):base(opt)
        {

        }
        public DbSet<College> college { get; set; }
        public DbSet<Stuff> Stuff { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Postion> Postion { get; set; }
        public DbSet<Mail> Mail { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Student> Student { get; set; }

        
    }
}
