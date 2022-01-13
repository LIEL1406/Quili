﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;
using BL;
using Entities;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace finalProject.Controllers
{

    [RoutePrefix("Api/Recipes")]
    public class RecipesController : ApiController
    {
        [HttpPut]
        [Route("AddRecipe")]
        public JsonResult<ReturnObject> AddRecipe(RecipesEntities r)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            if (headers.Contains("Authorization"))
            {
                r.Mail = headers.GetValues("Authorization").First();
            }
            else
            {
                return Json(new ReturnObject() { Status = false, Error = "Token is necessary" });
            }
            try
            {
                RecipesBl.AddRecipe(r);
                switch (r.SchedulingStatuse)
                {
                    //once
                    case 1:
                        SchedulesBl.AddSchedules(new SchedulesEntities() { RecipeCode = r.Code, Date = r.Date, Amount = 1 });
                        break;
                    //weekly
                    case 2:
                        for (int i = 0; i < 48; i++)
                        {
                            DateTime d = r.Date;
                            SchedulesBl.AddSchedules(new SchedulesEntities() { RecipeCode = r.Code, Date = d.AddDays(i * 7), Amount = 1 });
                        }
                        break;
                    //monthly
                    case 3:
                        for (int i = 0; i < 12; i++)
                        {
                            DateTime d = r.Date;
                            SchedulesBl.AddSchedules(new SchedulesEntities() { RecipeCode = r.Code, Date = d.AddMonths(i), Amount = 1 });
                        }
                        break;
                    default:
                        return Json(new ReturnObject() { Status = false, Error = "error" });
                }
            }
            catch (Exception ex)
            {

                return Json(new ReturnObject() { Status = false, Error = ex.ToString() });
            }
            if(!ProductsController.AddProducts(r.RecipeId, r.Code))
                return Json(new ReturnObject() { Status = false, Data = "AddProducts failed" });

            return Json(new ReturnObject() { Status = true, Data = r.Mail });
        }

        [HttpGet]
        [Route("SearchRecipe/{w}")]
        public JsonResult<ReturnObject> SearchRecipe(string w)
        {
            try
            {
                return Json(new ReturnObject() { Status = true, Data = ApiRecipes.SearchRecipe(w) });
            }
            catch (Exception ex)
            {
                return Json(new ReturnObject() { Status = false, Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetRecipeById/{id}")]
        public JsonResult<ReturnObject> GetRecipeById(string id)
        {
            try
            {
                return Json(new ReturnObject() { Status = true, Data = ApiRecipes.GetRecipeById(id) });
            }
            catch (Exception ex)
            {
                return Json(new ReturnObject() { Status = false, Error = ex.Message });
            }
        }
    }
}