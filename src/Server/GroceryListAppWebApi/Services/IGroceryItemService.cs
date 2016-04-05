using System.Collections.Generic;
using GroceryListAppWebApi.DTO;

namespace GroceryListAppWebApi.Services
{
    public interface IGroceryItemService
    {
        /// <summary>
        /// Get all grocery items.
        /// </summary>
        /// <returns>Returns a IEnumerable of grocery items.</returns>
        IEnumerable<GroceryItemDto> GetGroceryItems();

        /// <summary>
        /// Get grocery item with the given id.
        /// </summary>
        /// <returns>Returns the grocery item with the given id, or null if it does not exists.</returns>
        GroceryItemDto GetById(int itemId);

        /// <summary>
        /// Adds a new grocery item into database
        /// </summary>
        void Add(GroceryItemDto groceryItemDto);

        /// <summary>
        /// Update information of the given grocery item dto.
        /// The <see cref="GroceryItemDto.DateTimeCreated"/> property is ignored.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the given groceryItemDto instance does not have value for Id property.</exception>
        /// <exception cref="ObjectNotFoundException">Thrown if no grocery item can be found with the given Id.</exception>
        void Update(GroceryItemDto groceryItemDto);

        /// <summary>
        /// Delete the grocery item with the given id.
        /// </summary>
        void Delete(long id);
    }
}