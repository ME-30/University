using Microsoft.AspNetCore.Mvc;
using System;
using University.BL.Models;
using University.BL.Helper;
using University.BL.Interface;
using AutoMapper;
using University.DAL.Entity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace University.Controllers
{
    [Authorize]

    public class MailController : Controller
    {
        private readonly IMailRep Mail;
        private readonly IMapper mapper;

        public MailController(IMailRep Mail, IMapper mapper)
        {
            this.Mail = Mail;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["Msg"] = SendMailHelpar.SendMial(model);


                    var data = mapper.Map<Mail>(model);
                    Mail.Create(data);
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["Msg"] = "Message Fiald";
                    return View(model);
                }
               
            }
            catch (Exception ex)
            {

                TempData["Msg"] = "Error";
                return View();


            }

        }
        public IActionResult MailBox()
        {
            var data = Mail.GetAll();
            var model = mapper.Map<IEnumerable<MailVM>>(data);


            return View(model);
        }
    }
}
