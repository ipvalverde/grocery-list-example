using GroceryListAppWebApi.Models;
using GroceryListAppWebApi.Repositories;
using GroceryListAppWebApi.Services;
using SimpleInjector;

namespace GroceryListAppWebApi.App_Start
{
    public static class DependenciesRegistration
    {
        public static void RegisterDependencies(Container container)
        {
            container.Register<GroceryListContext>(Lifestyle.Scoped);
            container.Register<IGroceryItemRepository, GroceryItemRepository>(Lifestyle.Scoped);
            container.Register<IGroceryItemService, GroceryItemService>(Lifestyle.Scoped);
        }
    }
}