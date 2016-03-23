using System.Collections.Generic;
using GroceryListAppWebApi.Models;

namespace GroceryListAppWebApi.Services
{
    public interface IGroceryItemService
    {
        /// <summary>
        /// Get all grocery items.
        /// </summary>
        /// <returns>Returns a IEnumerable of grocery items.</returns>
        IEnumerable<GroceryItem> GetGroceryItems();
    }
}