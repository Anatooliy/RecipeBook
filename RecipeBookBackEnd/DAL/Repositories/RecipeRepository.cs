using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class RecipeRepository : IRepository
    {
        private RecipeContext db;

        public RecipeRepository(RecipeContext dbContext)
        {
            this.db = dbContext;
        }       

        public IEnumerable<Recipe> GetAll()
        {           
            return db.Recipes;
        }

        public Recipe Get(int id)
        {
            return db.Recipes.Find(id);
        }

        public void Create(Recipe recipe)
        {
            db.Recipes.Add(recipe);
        }

        public void Update(Recipe recipe)
        {
            db.Entry(recipe).State = EntityState.Modified;
        }

        public IEnumerable<Recipe> Find(Func<Recipe, bool> predicate)
        {
            return db.Recipes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe != null)
                db.Recipes.Remove(recipe);
        }   
        
        public void Save()
        {
            db.SaveChanges();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
             Dispose(true);
             GC.SuppressFinalize(this);
        }
    }
}
