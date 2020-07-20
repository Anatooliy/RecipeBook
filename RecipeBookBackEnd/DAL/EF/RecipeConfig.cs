using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.EF
{
    public class RecipeConfig : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfig()
        {
            HasIndex(p => new { p.ParentRecipeId, p.Name }).IsUnique();

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Description).IsRequired();
            Property(p => p.CreatedDate).IsRequired();
        }
    }
}
