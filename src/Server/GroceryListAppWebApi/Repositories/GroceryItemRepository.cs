using GroceryListAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}