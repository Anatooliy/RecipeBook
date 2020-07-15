using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Recipe> GetAll();
        Recipe Get(int id);
        IEnumerable<Recipe> Find(Func<Recipe, bool> predicate);
        void Create(Recipe recipe);
        void Update(Recipe recipe);
        void Delete(int id);
        void Save();
    }
}
