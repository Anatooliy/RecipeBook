using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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