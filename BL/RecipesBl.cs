﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Entities;

namespace BL
{
    public class RecipesBl
    {
        //שליפה
        //public static GetSavedRecipeById()
        //{

        //}
        //הוספה
        public static void AddRecipe(RecipesEntities r)
        {
            //RECIPES r2 = RecipesEntities.ConvertToDB(r);
            RecipesDal.AddRecipe(RecipesEntities.ConvertToDB(r));
            //r.Code = r2.CODE;

            //שליפת הקוד של המתכון האחרון שנוסף על מנת להציבו בתזמונים של המתכון
            //int codeLastRecipe = RecipesDal.GetRecipes().OrderByDescending(x => x.CODE).FirstOrDefault().CODE;
        }
    }
}
