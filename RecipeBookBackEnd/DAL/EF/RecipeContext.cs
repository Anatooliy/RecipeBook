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

        public RecipeContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new RecipeConfig());
        }
    }
}
