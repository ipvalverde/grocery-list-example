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

        /// <summary>
        /// Get grocery item with the given id.
        /// </summary>
        /// <returns>Returns the grocery item with the given id, or null if it does not exists.</returns>
        GroceryItem GetGroceryItem(long itemId);

        /// <summary>
        /// Creates a new grocery item with the given name and bought status.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bought"></param>
        void Create(string name, bool bought);

        /// <summary>
        /// Set the given grocery item as modified.
        /// </summary>
        /// <param name="groceryItem"></param>
        void Update(GroceryItem groceryItem);

        /// <summary>
        /// Delete the grovery item with the given id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);

        /// <summary>
        /// Apply the changes performed over this repository instance.
        /// </summary>
        void SaveChanges();
    }
}