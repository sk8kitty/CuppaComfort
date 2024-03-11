using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CuppaComfort.Models
{
    /// <summary>
    /// Represents an individual job application
    /// </summary>
    public class JobApplication
    {
        /// <summary>
        /// The unique ID of the application
        /// </summary>
        [Key]
        public int ApplicationId { get; set; }

        /// <summary>
        /// The unique ID of the user applying
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The applicant's preferred name
        /// </summary>
        [Required]
        [DisplayName("Preferred Name")]
        public string PreferredName { get; set; }

        /// <summary>
        /// The applicant's legal first name
        /// </summary>
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The applicant's legal last name
        /// </summary>
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// The applicant's birthday
        /// </summary>
        [Required]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// The applicant's email address
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The applicant's phone number
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// The position being applied for
        /// </summary>
        [Required]
        [DisplayName("Position")]
        public Position ChosenPosition { get; set; }

        /// <summary>
        /// The filepath of the user's uploaded resume
        /// </summary>
        [AllowNull]
        [DisplayName("Resume")]
        public string? ResumeFilepath { get; set; }

        /// <summary>
        /// The date that the application was submitted on
        /// </summary>
        [Required]
        [DisplayName("Submission Date")]
        public DateTime SubmissionDate { get; set; }

        /// <summary>
        /// The review status of the application (pending, accepted, or rejected)
        /// </summary>
        [Required]
        public string Status { get; set; }
    }
}
