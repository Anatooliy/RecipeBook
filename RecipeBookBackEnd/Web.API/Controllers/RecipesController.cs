using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.API.Models;

namespace Web.API.Controllers
{
    public class RecipesController : ApiController
    {
        IMapper iMapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipeDTO, RecipeViewModel>()).CreateMapper();

        private readonly IRecipeService recipeService;

        public RecipesController(IRecipeService recService)
        {
            this.recipeService = recService;
        }

        // GET api/values
        public IEnumerable<RecipeViewModel> Get()
        {
            return iMapper.Map<IEnumerable<RecipeDTO>, List<RecipeViewModel>>(recipeService.GetRecipes());
        }

        // GET api/values/5
        public RecipeViewModel Get(int id)
        {
            return iMapper.Map<RecipeDTO, RecipeViewModel>(recipeService.GetRecipe(id)); ;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
