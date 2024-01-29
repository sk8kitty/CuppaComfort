using System.ComponentModel.DataAnnotations;

namespace CuppaComfort.Models
{
    /// <summary>
    /// Represents an individual job position
    /// </summary>
    public class Position
    {
        /// <summary>
        /// The unique Id of the job position
        /// </summary>
        [Key]
        public int PositionId { get; set; }

        /// <summary>
        /// The title of the position
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Whether or not the position needs a hire
        /// </summary>
        [Required]
        public bool IsOpen { get; set; }
    }
}
