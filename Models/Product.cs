using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuppaComfort.Models
{
    /// <summary>
    /// Represents an individual coffee shop product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The unique ID of the product
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        /// <summary>
        /// The type of product (drink, snack, or drinkware)
        /// </summary>
        [Required]
        [DisplayName("Product Type")]
        public string Type { get; set; }

        /// <summary>
        /// What category the product is in (for the search function)
        /// Different categories exist for each type of product
        /// </summary>
        [Required]
        [DisplayName("Product Category")]
        public string Category { get; set; }

        /// <summary>
        /// A brief description of the product
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The cost of the product
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }


    /// <summary>
    /// Inherits Product class and represents a consumable product
    /// </summary>
    public class ConsumableProduct : Product
    {
        /// <summary>
        /// The list of ingredients in the consumable
        /// </summary>
        [Required]
        [DisplayName("Ingredient List")]
        public string IngredientList { get; set; }

        /// <summary>
        /// The nutritional information of the consumable
        /// </summary>
        [Required]
        [DisplayName("Nutrition Facts")]
        public string NutritionFacts { get; set; }

    }


    /// <summary>
    /// Inherits Product class and represents a merchandise product
    /// </summary>
    public class MerchandiseProduct : Product
    {
        /// <summary>
        /// The material of the product
        /// </summary>
        [Required]
        public string Material { get; set; }

        /// <summary>
        /// The dimensions of the product in inches
        /// </summary>
        [Required]
        public string Dimensions { get; set; }

        /// <summary>
        /// How much the product holds in ounces
        /// </summary>
        [Required]
        public string Volume { get; set; }
    }
}
