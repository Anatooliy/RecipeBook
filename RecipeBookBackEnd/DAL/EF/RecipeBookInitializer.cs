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
            Recipe recipeChickenMain = new Recipe
            {
                Name = "Fried Chicken",
                Description = "Description of Fried Chicken",
                CreatedDate = DateTime.Now.AddDays(-50)
            };

            Recipe recipeChickenSecondLevel = new Recipe
            {
                Name = "with Mayo",
                Description = "Description of Fried Chicken with Mayo",
                CreatedDate = DateTime.Now.AddDays(-40),
                ParentRecipe = recipeChickenMain
            };

            Recipe recipeChickenThirdLevel = new Recipe
            {
                Name = "and Mustard",
                Description = "Description of Fried Chicken with Mayo and Mustard",
                CreatedDate = DateTime.Now.AddDays(-30),
                ParentRecipe = recipeChickenSecondLevel
            };

            Recipe recipeChickenThirdLevel2 = new Recipe
            {
                Name = "and Chees",
                Description = "Description of Fried Chicken with Mayo and Chees",
                CreatedDate = DateTime.Now.AddDays(-30),
                ParentRecipe = recipeChickenSecondLevel
            };

            Recipe recipeApplePieMain = new Recipe
            {
                Name = "Apple Pie",
                Description = "Description of ApplePie",
                CreatedDate = DateTime.Now.AddDays(-100)
            };

            Recipe recipeApplePieSecondLevel = new Recipe
            {
                Name = "with cream",
                Description = "Description of Apple Pien with cream",
                CreatedDate = DateTime.Now.AddDays(-90),
                ParentRecipe = recipeApplePieMain
            };

            Recipe recipeApplePieSecondLevel2 = new Recipe
            {
                Name = "with cottage cheese",
                Description = "Description of Apple Pie with cottage cheese",
                CreatedDate = DateTime.Now.AddDays(-80),
                ParentRecipe = recipeApplePieMain
            };

            Recipe recipeApplePieThirdLevel = new Recipe
            {
                Name = "and with raisins",
                Description = "Description of Fried Apple Pie with cream and with raisins",
                CreatedDate = DateTime.Now.AddDays(-70),
                ParentRecipe = recipeApplePieSecondLevel
            };

            context.Recipes.AddRange(
                new List<Recipe>() {
                    recipeChickenMain,
                    recipeChickenSecondLevel,
                    recipeChickenThirdLevel,
                    recipeChickenThirdLevel2,
                    recipeApplePieMain,
                    recipeApplePieSecondLevel,
                    recipeApplePieSecondLevel2,
                    recipeApplePieThirdLevel
                });

            context.SaveChanges();

            //base.Seed(context);
        }
    }
}
