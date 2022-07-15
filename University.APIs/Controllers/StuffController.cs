using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using University.BL.Helper;
using University.BL.Interface;
using University.BL.Models;
using University.DAL.Entity;

namespace University.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuffController : ControllerBase
    {

        #region   fialda

        private readonly IStuffRep stuff;
        private readonly IMapper mapper;


        #endregion

        #region ctor

        public StuffController(IStuffRep stuff, IMapper mapper)
        {
            this.stuff = stuff;
            this.mapper = mapper;
        }



        #endregion


        #region   APIs
         [HttpGet()]
         [Route("~/Api/GetStuff")]
        public IActionResult GetStuff()
        {

            try
            {
               
                    var data = stuff.Get();
                    var model = mapper.Map<IEnumerable<StuffVM>>(data);

                    return Ok(new ApiResponse<IEnumerable<StuffVM>>()
                    {

                        Code = "200",
                        Status = "Ok",
                        Message = "Deta Retrieved",
                        Data = model

                    });

                

            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Ok",
                    Message = "Deta Faild",
                    Error = ex.Message

                });
            }


         
        }
      

        [HttpGet()]
        [Route("~/Api/GetStuffById/{id}")]
        public IActionResult GetStuffById(int id)
        {

            try
            {
                var data = stuff.GetById(id);
                var model = mapper.Map<StuffVM>(data);

                return Ok(new ApiResponse<StuffVM>()
                {

                    Code = "200",
                    Status = "Ok",
                    Message = "Deta Retrieved",
                    Data = model

                });

            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Found",
                    Error = ex.Message

                });
            }



        }

        [HttpPost()]
        [Route("~/Api/PostStuff")]
        public IActionResult PostStuff(StuffVM model)
        {

            try
            {
                var data = mapper.Map<Stuff>(model);
                var result = stuff.Create(data);

                if (ModelState.IsValid)
                {

                    return Ok(new ApiResponse<Stuff>()
                    {

                        Code = "201",
                        Status = "Created",
                        Message = "Deta Saved",
                        Data = result

                    });
                }
                return NotFound(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Requast",
                    Message = "Deta Not Found",

                });

            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Valied",
                    Message = "Deta Not Found",
                    Error = ex.Message

                });
            }



        }
        [HttpPut()]
        [Route("~/Api/PutStuff")]
        public IActionResult PutStuff(StuffVM model)
        {

            try
            {
                var data = mapper.Map<Stuff>(model);
                var result =  stuff.Edit(data);

                if (ModelState.IsValid)
                {

                    return Ok(new ApiResponse<Stuff>()
                    {

                        Code = "201",
                        Status = "Updated",
                        Message = "Deta Saved",
                        Data = result

                    });
                }
                return NotFound(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Requast",
                    Message = "Deta Not Found",

                });

            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Valied",
                    Message = "Deta Not Found",
                    Error = ex.Message

                });
            }



        }
       [HttpDelete()]
        [Route("~/Api/DeleteStuff")]
        public IActionResult DeleteStuff(StuffVM model)
        {

            try
            {
                var data = mapper.Map<Stuff>(model);
                var result =  stuff.Delete(data);

               

                    return Ok(new ApiResponse<Stuff>()
                    {

                        Code = "201",
                        Status = "Ok",
                        Message = "Deta Deleted",
                        Data = result

                    });
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Valied",
                    Message = "Deta Not Found",
                    Error = ex.Message

                });
            }



        }




        #endregion



    }
}
