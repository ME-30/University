using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using University.BL.Interface;
using University.BL.Models;
using University.BL.Repository;
using University.DAL.Entity;

namespace University.Controllers
{
    [Authorize]

    public class CollegeController : Controller
    {
        #region   Ctor

        private readonly ICollegeRep College;
        private readonly IMapper mapper;

        public CollegeController(ICollegeRep College, IMapper mapper)
        {
            this.College = College;
            this.mapper = mapper;
        }

        #endregion


        #region Actions

        //public IActionResult Index()
        //{
        //    var data = College.Get();
        //    var model = mapper.Map<IEnumerable<CollegeVM>>(data);

        //    return View(model);
        //}

        public IActionResult Index(string SearchValue = "")
        {
            if (SearchValue == "")
            {
                var data = College.Get();
                var model = mapper.Map<IEnumerable<CollegeVM>>(data);

                return View(model);
            }
            else
            {
                var data = College.SearchByName(SearchValue);
                var model = mapper.Map<IEnumerable<StuffVM>>(data);

                return View(model);
            }

        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CollegeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<College>(model);
                    College.Create(data);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch (Exception ex)
            {

                return View(model);
            }


        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var data = College.GetById(id);
            var model = mapper.Map<CollegeVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CollegeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<College>(model);
                    College.Edit(data);
                    return RedirectToAction("Index");
                }
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
            var data = College.GetById(id);
            var model = mapper.Map<CollegeVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(CollegeVM model)
        {
            try
            {
                var data = mapper.Map<College>(model);
                College.Delete(data);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View(model);
            }
        }
        public IActionResult Details(int id)
        {
            var data = College.GetById(id);

            var model = mapper.Map<CollegeVM>(data);
            return View(model);
        }



        #endregion



    }
}
