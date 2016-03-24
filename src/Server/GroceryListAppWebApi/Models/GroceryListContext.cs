using System.Data.Entity;

namespace GroceryListAppWebApi.Models
{
    public class GroceryListContext : DbContext
    {
        public GroceryListContext()
            :base("PostgreConnectionString")
        {
            Database.SetInitializer<GroceryListContext>(new GroceryListContextInitializer());

            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<GroceryItem> GroceryItems { get; set; }
    }
}