using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Helpers
{
    class RecipeHelper
    {
        public IMapper GetRecipeToRecipeDtoMapper()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipeDTO>()                
                .ForMember(dto => dto.NamesTree, recipe => recipe.MapFrom(r => GetRecipesTree(r))))
                .CreateMapper();
        }       

        private IEnumerable<NamesTreeNodeDTO> GetRecipesTree(Recipe recipe)
        {
            Dictionary<int, StringBuilder> recipesTree = new Dictionary<int, StringBuilder>();            
            
            while (recipe != null)
            {
                foreach (var key in recipesTree.Keys.ToList())
                {
                    recipesTree[key] = recipesTree[key].Insert(0, $"{recipe.Name} ");
                }

                recipesTree.Add(recipe.Id, new StringBuilder(recipe.Name));
                recipe = recipe.ParentRecipe;                
            }

            return recipesTree.Select(r => new NamesTreeNodeDTO() { 
                Id = r.Key,
                Name = r.Value.ToString()
            });
        }
    }
}
