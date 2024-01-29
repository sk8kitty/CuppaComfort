using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuppaComfort.Models
{
    /// <summary>
    /// Represents an individual feedback form
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// The unique ID of the feedback form
        /// </summary>
        [Key]
        public int FeedbackId { get; set; }

        /// <summary>
        /// The unique ID of the user submitting the feedback
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The feedback message provided by the user
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// The shop rating on a 1-5 scale by the user
        /// </summary>
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        /// <summary>
        /// The status that determines whether or not the feedback is displayed on the homepage;
        /// Exists and is modified by website admins to prevent displaying hateful feedback
        /// </summary>
        [Required]
        public bool DisplayApproved { get; set; }
    }
}
