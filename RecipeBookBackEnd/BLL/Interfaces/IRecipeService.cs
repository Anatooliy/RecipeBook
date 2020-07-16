using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRecipeService
    {
        RecipeDTO GetRecipe(int? id);
        IEnumerable<RecipeDTO> GetRecipes();
        void UpdateRecipe(RecipeDTO recipeDto);
        void CreateRecipe(RecipeDTO recipeDto);
        void DeleteRecipe(int id);
        void Dispose();
    }
}
