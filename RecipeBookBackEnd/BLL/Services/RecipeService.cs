using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RecipeService : IRecipeService
    {        
        IRepository db { get; set; }

        public RecipeService(IRepository repository)
        {
            db = repository;
        }

        public IEnumerable<RecipeDTO> GetRecipes()
        {
            IMapper iMapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipeDTO>()).CreateMapper();

            return iMapper.Map<IEnumerable<Recipe>, List<RecipeDTO>>(db.GetAll());
        }

        public RecipeDTO GetRecipe(int? id)
        {
            IMapper iMapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipeDTO>()).CreateMapper();

            return iMapper.Map<Recipe, RecipeDTO>(db.Get(id.Value));            
        }   
        
        public void CreateRecipe(RecipeDTO recipeDTO)
        {
            Recipe recipe = new MapperConfiguration(cfg => cfg.CreateMap<RecipeDTO, Recipe>())
                .CreateMapper()
                .Map<RecipeDTO, Recipe>(recipeDTO);

            recipe.CreatedDate = DateTime.UtcNow;

            db.Create(recipe);
            db.Save();
        }

        public void UpdateRecipe(RecipeDTO recipeDTO)
        {
            Recipe recipe = new MapperConfiguration(cfg => cfg.CreateMap<RecipeDTO, Recipe>())
                .CreateMapper()
                .Map<RecipeDTO, Recipe>(recipeDTO);

            db.Update(recipe);
            db.Save();
        }

        public void DeleteRecipe(int id)
        {
            db.Delete(id);
            db.Save();
        }

        public void Dispose()
            {
                db.Dispose();
            }
        }
}
