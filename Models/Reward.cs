using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuppaComfort.Models
{
    public class Reward
    {
        /// <summary>
        /// The unique ID of the reward
        /// </summary>
        [Key]
        public int RewardId { get; set; }

        /// <summary>
        /// The code that will be used to utilize the reward
        /// </summary>
        [Required]
        public string Code { get; set; }
        
        /// <summary>
        /// The type of reward (universal or personal)
        /// Personal reward codes can be discarded and recycled after use
        /// Universal rewards should not be discarded
        /// </summary>
        [Required]
        [DisplayName("Reward Type")]
        public string RewardType { get; set; }



        // percentage type reward (15% off)
        /// <summary>
        /// Whether or not the reward uses percentage format
        /// </summary>
        [Required]
        [DisplayName("Percentage?")]
        public bool IsPercentage { get; set; }

        /// <summary>
        /// If the reward is a percentage, this is the percentage
        /// </summary>
        [DisplayName("Discount Percentage")]
        public int DiscountPercentage { get; set; }


        // flat amount type reward ($5 off)
        /// <summary>
        /// Whether or not the reward uses a flat amount format
        /// </summary>
        [Required]
        [DisplayName("Flat Amount?")]
        public bool IsFlatAmount { get; set; }

        /// <summary>
        /// If the reward is a flat amount, this is the amount
        /// </summary>
        [DisplayName("Discount Amount")]
        public int DiscountAmount { get; set; }


        // free waiver type reward (cold drink free, etc.)
        /// <summary>
        /// Whether or not the reward is a free waiver
        /// </summary>
        [Required]
        [DisplayName("Free Waiver?")]
        public bool IsFreeWaiver { get; set; }

    }
}
