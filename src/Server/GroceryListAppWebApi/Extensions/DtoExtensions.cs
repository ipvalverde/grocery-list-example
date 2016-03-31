using GroceryListAppWebApi.DTO;
using GroceryListAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryListAppWebApi.Extensions
{
    public static class DtoExtensions
    {
        public static IEnumerable<GroceryItemDto> ToDto(this IEnumerable<GroceryItem> groceryItems)
        {
            return groceryItems.Select(groceryItem => groceryItem.ToDto());
        }

        public static GroceryItemDto ToDto(this GroceryItem groceryItem)
        {
            return new GroceryItemDto
            {
                Id = groceryItem.Id,
                Bought = groceryItem.Bought,
                DateTimeCreated = groceryItem.DateTimeCreated,
                Name = groceryItem.Name
            };
        }
    }
}