using System;

namespace BLL.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Description { get; set; }       
        public DateTime CreatedDate { get; set; }
        public int ParentRecipeId { get; set; }        
    }
}
