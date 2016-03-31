using System;
using System.Data.Entity;

namespace GroceryListAppWebApi.Models
{
    public class GroceryListContextInitializer : DropCreateDatabaseAlways<GroceryListContext>
    {
        protected override void Seed(GroceryListContext context)
        {
            context.GroceryItems.Add(new GroceryItem { Bought= false, Name= "Milk", DateTimeCreated= new DateTime(2016, 3, 9, 12, 0, 0) });
            context.GroceryItems.Add(new GroceryItem { Bought= false, Name= "Meat", DateTimeCreated = new DateTime(2016, 3, 9, 12, 0, 0) });
            context.GroceryItems.Add(new GroceryItem { Bought= false, Name= "Banana", DateTimeCreated = new DateTime(2016, 3, 9, 12, 0, 0) });
            context.GroceryItems.Add(new GroceryItem { Bought= true, Name= "Chocolates", DateTimeCreated = new DateTime(2016, 3, 1, 12, 0, 0) });
            context.GroceryItems.Add(new GroceryItem { Bought= true, Name= "Chicken wings", DateTimeCreated = new DateTime(2016, 3, 9, 12, 0, 0) });
            context.GroceryItems.Add(new GroceryItem { Bought= true, Name= "Apple", DateTimeCreated = new DateTime(2016, 3, 1, 12, 0, 0) });
            context.GroceryItems.Add(new GroceryItem { Bought= false, Name= "Loaf of bread", DateTimeCreated = new DateTime(2016, 3, 10, 12, 0, 0) });
            context.GroceryItems.Add(new GroceryItem { Bought= false, Name= "Coca cola", DateTimeCreated = new DateTime(2016, 3, 10, 12, 0, 0) });

            base.Seed(context);
        }
    }
}