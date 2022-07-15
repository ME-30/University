using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using University.BL.Interface;
using University.BL.Models;
using University.BL.Repository;
using University.DAL.Entity;

namespace University.Controllers
{
    [Authorize(Roles = "admin ,Doctor ,Student")]
    public class StuffController : Controller
    {

        #region   Fiels
             private readonly IStuffRep stuff;
        private readonly ICollegeRep collegeRep;
        private readonly ITracksRep tracks;
        private readonly IPostionsRep postion;
        private readonly IMapper mapper;
        #endregion

       
        #region Ctor
        public StuffController(IStuffRep stuff ,ICollegeRep collegeRep, ITracksRep tracks , IPostionsRep postion ,IMapper mapper)
        {
            this.stuff = stuff;
            this.collegeRep = collegeRep;
            this.tracks = tracks;
            this.postion = postion;
            this.mapper = mapper;
        }
        #endregion
        public IActionResult Index(string SearchValue = "")
        {
            if (SearchValue == "")
            {
                 var data = stuff.Get();
                 var model = mapper.Map< IEnumerable <StuffVM>>(data);

                 return View(model);
            }
            else
            {
                var data = stuff.SearchByName(SearchValue);
                var model = mapper.Map< IEnumerable <StuffVM>>(data);

                return View(model);
            }
           
        }

        [Authorize(Roles = "admin ,Doctor")]
        public IActionResult Create()
        {
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id" ,"Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(StuffVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Stuff>(model);

                    stuff.Create(data);

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
 
        [Authorize(Roles = "admin ,Doctor")]
        public IActionResult Edit(int id)
        {
            var data =  stuff.GetById(id);
            var model = mapper.Map<StuffVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(StuffVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Stuff>(model);

                    stuff.Edit(data);

                    return RedirectToAction("Index");

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
            var data = stuff.GetById(id);
            var model = mapper.Map<StuffVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(), "Id", "Name", model.CollegeId);

            return View(model) ;
        }
        [HttpPost]
        public IActionResult Delete(StuffVM model)
        {
            try
            {
                var data = mapper.Map<Stuff>(model);
                stuff.Delete(data);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public IActionResult Details(int id )
        {
            var data = stuff.GetById(id);
            var model = mapper.Map<StuffVM>(data);
            ViewBag.CollegeList = new SelectList(collegeRep.Get(),"Id","Name",model.CollegeId);

            return View (model);
        }

        #region Ajax Requests
        [HttpPost]
        public JsonResult GetPostionDataByTracksId(int trkId)
        {
            var data = postion.GetAll(a=> a.TrackId == trkId);
            var model = mapper.Map<IEnumerable<PostionVM>>(data);

            return Json(model);
        } 

        #endregion
    }
}
