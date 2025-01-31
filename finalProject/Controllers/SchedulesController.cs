﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BL;
using Entities;

namespace finalProject.Controllers
{
    [RoutePrefix("Api/Schedules")]
    public class SchedulesController : ApiController
    {
        [HttpGet]
        [Route("GetSchedulesByRange/{d1}/{d2}")]
        public JsonResult<ReturnObject> GetSchedulesByRange(DateTime d1, DateTime d2)
        {
            string mail = "";
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            if (headers.Contains("Authorization"))
            {
                mail = headers.GetValues("Authorization").First();
            }
            else
            {
                return Json(new ReturnObject() { Status = false, Error = "Email is required!" });
            }
            try
            {
                var data = SchedulesBl.GetSchedulesByRange(d1, d2, mail);
                return Json(new ReturnObject() { Status = true, Data = data });
            }
            catch (Exception ex)
            {
                return Json(new ReturnObject() { Status = false, Error = ex.ToString() });
            }
        }

        [HttpGet]
        [Route("GetProductsByRange/{d1}/{d2}")]
        public JsonResult<ReturnObject> GetProductsByRange(DateTime d1, DateTime d2)
        {
           string mail = "";
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            if (headers.Contains("Authorization"))
            {
                mail = headers.GetValues("Authorization").First();
            }
            else
            {
                return Json(new ReturnObject() { Status = false, Error = "Email is required!" });
            }
            try
            {
                List<SchedulesEntities> Schedules = SchedulesBl.GetSchedulesByRange(d1, d2, mail);
                List<ProductsEntities> list = new List<ProductsEntities>();

                foreach (var s in Schedules)
                {
                    var list1 = ProductsController.GetRecipeProducts(s.RecipeCode, s.Code);
                    foreach (var p in list1)
                    {
                        list.Add(p);
                    }
                }
                //var data =
                //from info in list
                //orderby info.ProductName ascending, info.ProductName ascending
                //select info;
                return Json(new ReturnObject() { Status = true, Data = list });
            }
            catch (Exception ex)
            {
                return Json(new ReturnObject() { Status = false, Error = ex.ToString() });
            }
        }

        [HttpDelete]
        [Route("RemoveSchedules/{id}/{rec}")]
        public JsonResult<ReturnObject> RemoveSchedules(short id, int rec)
        {
            try
            {
                SchedulesBl.RemoveSchedule(id, rec);
                return Json(new ReturnObject() { Status = true, Data = id });
            }
            catch (Exception ex)
            {
                return Json(new ReturnObject() { Status = false, Error = ex.ToString() });
            }
        }
    }
}