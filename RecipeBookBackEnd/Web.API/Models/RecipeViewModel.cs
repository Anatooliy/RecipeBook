using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Web.API.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<TreeNodeViewModel> NamesTree { get; set; }
        
        [JsonProperty(PropertyName = "parentId")]
        public int? ParentRecipeId { get; set; }
    }
}