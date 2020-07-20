using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }       
        public DateTime CreatedDate { get; set; }
        public List<NamesTreeNodeDTO> NamesTree { get; set; }
        public int? ParentRecipeId { get; set; }
    }
}
