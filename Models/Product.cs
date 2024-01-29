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
        public int ProductId { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of product (drink, snack, or drinkware)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A brief description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The cost of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// What category the product is in (for the search function)
        /// </summary>
        public ProductCategory Category { get; set; }

    }


    /// <summary>
    /// Inherits Product class and represents a consumable product
    /// </summary>
    public class ConsumableProduct : Product
    {
        /// <summary>
        /// The list of ingredients in the consumable
        /// </summary>
        public string IngredientList { get; set; }

        /// <summary>
        /// The nutritional information of the consumable
        /// </summary>
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
        public string Material { get; set; }

        /// <summary>
        /// The dimensions of the product in inches
        /// </summary>
        public string Dimensions { get; set; }

        /// <summary>
        /// How much the product holds in ounces
        /// </summary>
        public string Volume { get; set; }
    }
}
