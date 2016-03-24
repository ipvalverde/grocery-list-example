using GroceryListAppWebApi.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryListAppWebApi.Models
{
    public class GroceryItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(300, ErrorMessageResourceName="GroceryItemNameTooShort", ErrorMessageResourceType = typeof(ValidationResource))]
        [MinLength(3, ErrorMessageResourceName = "GroceryItemNameTooLong", ErrorMessageResourceType = typeof(ValidationResource))]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessageResourceName ="GroceryItemNameInvalid", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Name { get; set; }

        public bool Bought { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}