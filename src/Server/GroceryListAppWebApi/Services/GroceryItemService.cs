using GroceryListAppWebApi.Models;
using GroceryListAppWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public IEnumerable<GroceryItem> GetGroceryItems()
        {
            return this._groceryItemRepository.GetGroceryItems();
        }
    }
}