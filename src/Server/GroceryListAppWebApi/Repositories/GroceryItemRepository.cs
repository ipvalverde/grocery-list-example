using GroceryListAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryListAppWebApi.Repositories
{
    public class GroceryItemRepository : IGroceryItemRepository
    {
        private readonly GroceryListContext _context;

        public GroceryItemRepository(GroceryListContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Get all grocery items.
        /// </summary>
        /// <returns>Returns a IEnumerable of grocery items.</returns>
        public IEnumerable<GroceryItem> GetGroceryItems()
        {
            // TODO filter grocery items by current logged user
            return this._context.GroceryItems.ToList();
        }

        /// <summary>
        /// Get grocery item with the given id.
        /// </summary>
        /// <returns>Returns the grocery item with the given id, or null if it does not exists.</returns>
        public GroceryItem GetGroceryItem(long itemId)
        {
            // TODO filter grocery items by current logged user
            return this._context.GroceryItems.Find(itemId);
        }

        /// <summary>
        /// Creates a new grocery item with the given name and bought status.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bought"></param>
        public void Create(string name, bool bought)
        {
            this._context.GroceryItems.Add(new GroceryItem
            {
                Name = name,
                Bought = bought,
                DateTimeCreated = DateTime.UtcNow
            });
        }

        /// <summary>
        /// Set the given grocery item as modified.
        /// </summary>
        /// <param name="groceryItem"></param>
        public void Update(GroceryItem groceryItem)
        {
            // TODO check if the item being updated is owned by the current logged user
            this._context.Entry(groceryItem).State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// Delete the grovery item with the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            GroceryItem item = new GroceryItem() { Id = id };
            this._context.GroceryItems.Attach(item);
            this._context.GroceryItems.Remove(item);
        }

        /// <summary>
        /// Apply the changes performed over this repository instance.
        /// </summary>
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}