using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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
        public int ApplicationId { get; set; }

        /// <summary>
        /// The unique ID of the user applying
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The applicant's preferred name
        /// </summary>
        public string PreferredName { get; set; }

        /// <summary>
        /// The applicant's legal first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The applicant's legal last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The applicant's birthday
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// The applicant's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The applicant's phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The position being applied for
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// The kind of employment being applied for (full-time, part-time, temporary)
        /// </summary>
        public string EmploymentType { get; set; }

        /// <summary>
        /// The filepath of the user's uploaded resume
        /// </summary>
        public string ResumeFilepath { get; set; }

        /// <summary>
        /// The review status of the application (pending, accepted, or rejected)
        /// </summary>
        public string Status { get; set; }
    }
}
