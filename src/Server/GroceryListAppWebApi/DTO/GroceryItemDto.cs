﻿using GroceryListAppWebApi.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryListAppWebApi.DTO
{
    public class GroceryItemDto
    {
        public long? Id { get; set; }

        [Required]
        [MaxLength(120, ErrorMessageResourceName = "GroceryItemNameTooLong", ErrorMessageResourceType = typeof(ValidationResource))]
        [MinLength(3, ErrorMessageResourceName = "GroceryItemNameTooShort", ErrorMessageResourceType = typeof(ValidationResource))]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessageResourceName = "GroceryItemNameInvalid", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Name { get; set; }

        public bool Bought { get; set; }

        public DateTime? DateTimeCreated { get; set; }
    }
}