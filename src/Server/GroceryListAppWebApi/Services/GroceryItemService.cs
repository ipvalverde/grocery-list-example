using GroceryListAppWebApi.DTO;
using GroceryListAppWebApi.Extensions;
using GroceryListAppWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;

namespace GroceryListAppWebApi.Services
{
    public class GroceryItemService : IGroceryItemService
    {
        private readonly IGroceryItemRepository _groceryItemRepository;

        public GroceryItemService(IGroceryItemRepository groceryItemRepository)
        {
            this._groceryItemRepository = groceryItemRepository;
        }

        /// <summary>
        /// Get all grocery items.
        /// </summary>
        /// <returns>Returns all grocery items.</returns>
        public IEnumerable<GroceryItemDto> GetGroceryItems()
        {
            return this._groceryItemRepository.GetGroceryItems().ToDto();
        }

        /// <summary>
        /// Get grocery item with the given id.
        /// </summary>
        /// <returns>Returns the grocery item with the given id, or null if it does not exists.</returns>
        public GroceryItemDto GetById(int itemId)
        {
            return this._groceryItemRepository.GetGroceryItem(itemId).ToDto();
        }

        /// <summary>
        /// Adds a new grocery item into database
        /// </summary>
        public void Add(GroceryItemDto groceryItemDto)
        {
            if (groceryItemDto == null)
                throw new ArgumentNullException("groceryItemDto");

            this._groceryItemRepository.Create(groceryItemDto.Name,
                groceryItemDto.Bought);
            this._groceryItemRepository.SaveChanges();
        }

        /// <summary>
        /// Update information of the given grocery item dto.
        /// The <see cref="GroceryItemDto.DateTimeCreated"/> property is ignored.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the given groceryItemDto instance does not have value for Id property.</exception>
        /// <exception cref="ObjectNotFoundException">Thrown if no grocery item can be found with the given Id.</exception>
        public void Update(GroceryItemDto groceryItemDto)
        {
            if (groceryItemDto == null)
                throw new ArgumentNullException("groceryItemDto");

            if (!groceryItemDto.Id.HasValue)
                throw new ArgumentException("In order to update a grocery item, its id must be provided.");

            var groceryItem = this._groceryItemRepository.GetGroceryItem(groceryItemDto.Id.Value);
            if (groceryItem == null)
                throw new ObjectNotFoundException("The object with the given id could not be found.");

            // Update grocery item properties
            groceryItem.Bought = groceryItemDto.Bought;
            groceryItem.Name = groceryItemDto.Name;

            this._groceryItemRepository.Update(groceryItem);
            this._groceryItemRepository.SaveChanges();
        }
    }
}