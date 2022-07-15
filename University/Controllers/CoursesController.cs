using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using University.BL.Helper;
using University.BL.Interface;
using University.BL.Models;
using University.BL.Repository;
using University.DAL.Entity;


namespace University.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {

        #region   Fiels
        private readonly ICoursesRep courses;
        private readonly ICollegeRep collegeRep;
        private readonly IMapper mapper;
        #endregion


        #region Ctor
        public CoursesController(ICoursesRep courses, ICollegeRep collegeRep,  IMapper mapper)
        {
            this.courses = courses;
            this.collegeRep = collegeRep;
          
            this.mapper = mapper;
        }
        #endregion
        public IActionResult Index(string SearchValue = "" )
        {
            if (SearchValue == "")
            {
                var data = courses.Get();
                var model = mapper.Map<IEnumerable<CoursesVM>>(data);

                return View(model);
            }
            else
            {
                var data = courses.SearchByName(SearchValue);
                var model = mapper.Map<IEnumerable<CoursesVM>>(data);

                return View(model);
            }
        }

        [Authorize(Roles = "admin ,Doctor")]

        public IActionResult Create()
        {
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CoursesVM model)
        {

            try
            {


                if (ModelState.IsValid)
                {
                    model.MaterialName = FileUploder.UploadFile("/wwwroot/Files/Courses", model.MaterialUrl);
                    model.ExamName = FileUploder.UploadFile("/wwwroot/Files/Exams", model.ExamUrl);

                    var data = mapper.Map<Courses>(model);
                   
                    courses.Create(data);

                    return  RedirectToAction("Index");

                }

                ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name");
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }
        [Authorize(Roles = "admin ,Doctor")]

        public IActionResult Edit(int id)
        {
            var data = courses.GetById(id);
            var model = mapper.Map<CoursesVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CoursesVM model)
        {

            try
            {
                //var coursesInDB = courses.GetById(model.id);

                if (model.MaterialUrl != null)
                {
                    FileUploder.RemoveFile("/wwwroot/Files/Courses/", model.MaterialName);
                    model.MaterialName = FileUploder.UploadFile("/wwwroot/Files/Courses/", model.MaterialUrl);
                }
                //else
                //{
                //    model.MaterialName = coursesInDB.MaterialName;
                //}

                if (model.ExamUrl != null)
                {
                    FileUploder.RemoveFile("/wwwroot/Files/Exams/", model.ExamName);
                    model.ExamName = FileUploder.UploadFile("/wwwroot/Files/Exams/", model.ExamUrl);
                }
                //else
                //{
                //    model.ExamName = coursesInDB.ExamName;
                //}

                ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);
                var data = mapper.Map<Courses>(model);
                courses.Edit(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View(model);
            }
        }

        [Authorize(Roles = "admin ,Doctor")]
        public IActionResult Delete(int id)
        {
            var data = courses.GetById(id);
            var model = mapper.Map<CoursesVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(CoursesVM model)
        {
            try
            {
                var data = mapper.Map<Courses>(model);
                courses.Delete(data);
                FileUploder.RemoveFile("/wwwroot/Files/Courses/", model.MaterialName);
                FileUploder.RemoveFile("/wwwroot/Files/Exams/", model.ExamName);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public IActionResult Details(int id)
        {
            var data = courses.GetById(id);
            var model = mapper.Map<CoursesVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);

            return View(model);
        }
    }
}
