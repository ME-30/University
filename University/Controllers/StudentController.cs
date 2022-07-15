
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using University.BL.Interface;
using University.BL.Models;
using University.DAL.Entity;

namespace University.Controllers
{
    [Authorize(Roles = "admin ,Doctor ,Student")]
    public class StudentController : Controller
    {

        #region   Fiels
        private readonly IStudentRep student;
        private readonly ICollegeRep collegeRep;
       
        private readonly IMapper mapper;
        #endregion


        #region Ctor
        public StudentController(IStudentRep student, ICollegeRep collegeRep,  IMapper mapper)
        {
            this.student = student;
            this.collegeRep = collegeRep;
           
            this.mapper = mapper;
        }
        #endregion
        public IActionResult Index(string SearchValue = "" )
        {
            
            if (SearchValue == "")
            {
                var data = student.Get();
                var model = mapper.Map<IEnumerable<StudentVM>>(data);
                
                return View(model);
            }
            else
            {
                var data = student.SearchByName(SearchValue);
                var model = mapper.Map<IEnumerable<StudentVM>>(data);

                return View(model);
            }
           
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Student>(model);

                    student.Create(data);
                    RedirectToAction("Index");

                }

                ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var data = student.GetById(id);
            var model = mapper.Map<StudentVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(StudentVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Student>(model);

                    student.Edit(data);

                 return   RedirectToAction("Index");

                }
                ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);


                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var data = student.GetById(id);
            var model = mapper.Map<StudentVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(StudentVM model)
        {
            try
            {
                var data = mapper.Map<Student>(model);
                student.Delete(data);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public IActionResult Details(int id)
        {
            var data = student.GetById(id);
            var model = mapper.Map<StudentVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);

            return View(model);
        }
    }
}
