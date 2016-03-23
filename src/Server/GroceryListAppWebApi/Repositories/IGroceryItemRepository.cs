using GroceryListAppWebApi.Models;
using System.Collections.Generic;

namespace GroceryListAppWebApi.Repositories
{
    public interface IGroceryItemRepository
    {
        /// <summary>
        /// Get all grocery items.
        /// </summary>
        /// <returns>Returns a IEnumerable of grocery items.</returns>
        IEnumerable<GroceryItem> GetGroceryItems();
    }
}