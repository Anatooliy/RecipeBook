using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RecipeContext db;
        private RecipeRepository recipeRepository;

        public EFUnitOfWork()
        {
            db = new RecipeContext();
        }

        public IRepository<Recipe> Recipes
        {
            get
            {
                if (recipeRepository == null)
                    recipeRepository = new RecipeRepository(db);
                return recipeRepository;
            }
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
