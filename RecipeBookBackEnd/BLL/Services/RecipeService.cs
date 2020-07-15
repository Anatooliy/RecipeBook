﻿using AutoMapper;
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
        IMapper iMapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipeDTO>()).CreateMapper();
        IRepository db { get; set; }

        public RecipeService(IRepository repository)
        {
            db = repository;
        }

        public IEnumerable<RecipeDTO> GetRecipes()
        {
            return iMapper.Map<IEnumerable<Recipe>, List<RecipeDTO>>(db.GetAll());
        }

        public RecipeDTO GetRecipe(int? id)
        {
            return iMapper.Map<Recipe, RecipeDTO>(db.Get(id.Value));            
        }        

        public void Dispose()
        {
            db.Dispose();
        }
    }
}