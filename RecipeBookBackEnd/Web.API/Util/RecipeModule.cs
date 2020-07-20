using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace Web.API.Util
{
    public class RecipeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRecipeService>().To<RecipeService>();
        }
    }
}