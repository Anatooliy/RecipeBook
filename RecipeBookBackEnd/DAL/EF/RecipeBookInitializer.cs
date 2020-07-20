using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.EF
{
    public class RecipeBookInitializer : DropCreateDatabaseAlways<RecipeContext>
    {
        protected override void Seed(RecipeContext context)
        {
            Recipe recipeMain = new Recipe
            {
                Name = "Fried Chicken",
                Description = "Description of Fried Chicken",
                CreatedDate = DateTime.Now.AddDays(-50)
            };

            Recipe recipeSecondLevel = new Recipe
            {
                Name = "with Mayo",
                Description = "Description of Fried Chicken with Mayo",
                CreatedDate = DateTime.Now.AddDays(-40),
                ParentRecipe = recipeMain
            };

            Recipe recipeThirdLevel = new Recipe
            {
                Name = "and Mustard",
                Description = "Description of Fried Chicken with Mayo and Mustard",
                CreatedDate = DateTime.Now.AddDays(-30),
                ParentRecipe = recipeSecondLevel
            };

            Recipe recipeThirdLevel2 = new Recipe
            {
                Name = "and Chees",
                Description = "Description of Fried Chicken with Mayo and Mustard",
                CreatedDate = DateTime.Now.AddDays(-30),
                ParentRecipe = recipeSecondLevel
            };

            context.Recipes.AddRange(
                new List<Recipe>() {
                    recipeMain,
                    recipeSecondLevel,
                    recipeThirdLevel,
                    recipeThirdLevel2
                });

            context.SaveChanges();

            //base.Seed(context);
        }
    }
}
