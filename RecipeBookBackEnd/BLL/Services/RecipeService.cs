using AutoMapper;
using BLL.DTO;
using BLL.Extensions;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class RecipeService : IRecipeService
    {
        IUnitOfWork db { get; set; }

        public RecipeService(IUnitOfWork uof)
        {
            db = uof;
        }

        public IEnumerable<RecipeDTO> GetRecipes()
        {

            var orderedRecipes = db.Recipes.GetAll().Where(item => item.ParentRecipe == null).OrderBy(item => item.Name)
                            .Expand(item => item.Recipes != null && item.Recipes.Any() ? item.Recipes.OrderBy(child => child.Name) : null);

            return new RecipeHelper()
                .GetRecipeToRecipeDtoMapper()
                .Map<IEnumerable<Recipe>, List<RecipeDTO>>(orderedRecipes);
        }

        public RecipeDTO GetRecipe(int? id)
        {
            return new RecipeHelper()
                .GetRecipeToRecipeDtoMapper()
                .Map<Recipe, RecipeDTO>(db.Recipes.Get(id.Value));            
        }   
        
        public void CreateRecipe(RecipeDTO recipeDTO)
        {
            Recipe recipe = new MapperConfiguration(cfg => cfg.CreateMap<RecipeDTO, Recipe>())
                .CreateMapper()
                .Map<RecipeDTO, Recipe>(recipeDTO);

            recipe.CreatedDate = DateTime.UtcNow;

            db.Recipes.Create(recipe);
            db.Save();
        }

        public void UpdateRecipe(RecipeDTO recipeDTO)
        {
            Recipe recipe = new MapperConfiguration(cfg => cfg.CreateMap<RecipeDTO, Recipe>())
                .CreateMapper()
                .Map<RecipeDTO, Recipe>(recipeDTO);

            db.Recipes.Update(recipe);
            db.Save();
        }

        public void DeleteRecipe(int id)
        {
            db.Recipes.Delete(id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
