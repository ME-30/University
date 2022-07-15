using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.DAL.Entity;

namespace University.BL.Mapper
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<College, CollegeVM>();
            CreateMap<CollegeVM , College>();

            CreateMap<Stuff, StuffVM>();
            CreateMap<StuffVM, Stuff>();


             CreateMap<Tracks, TrackVM>();
            CreateMap<TrackVM, Tracks>();
            
            
            CreateMap<Mail, MailVM>();
            CreateMap<MailVM, Mail>();


             CreateMap<Postion, PostionVM>();
            CreateMap<PostionVM, Postion>();

            CreateMap<Student, StudentVM>();
            CreateMap<StudentVM, Student>();

            CreateMap<Courses, CoursesVM>();
            CreateMap<CoursesVM, Courses>();



        }

    }
}
