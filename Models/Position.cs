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
        /// The job description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The prerequisites of the job
        /// </summary>
        [Required]
        public string Prerequisites { get; set; }

        /// <summary>
        /// The benefits of the job
        /// </summary>
        public string Benefits { get; set; }

        /// <summary>
        /// The job's pay per hour
        /// </summary>
        [Required]
        public decimal Pay { get; set; }

        /// <summary>
        /// Whether or not the position needs a hire
        /// </summary>
        [Required]
        public bool IsOpen { get; set; }
    }
}
