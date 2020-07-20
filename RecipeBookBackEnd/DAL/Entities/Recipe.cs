using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Recipe
    {
        public int Id { get; set; }        
        public string Name { get; set; }       
        public string Description { get; set; }       
        public DateTime CreatedDate { get; set; }
        public int? ParentRecipeId { get; set; }
        public virtual Recipe ParentRecipe { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public Recipe()
        {
            Recipes = new List<Recipe>();
        }
    }
}
