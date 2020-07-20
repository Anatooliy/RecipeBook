using DAL.Entities;
using System.Data.Entity;

namespace DAL.EF
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        static RecipeContext()
        {
            Database.SetInitializer<RecipeContext>(new RecipeBookInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new RecipeConfig());
        }
    }
}
