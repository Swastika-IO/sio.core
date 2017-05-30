using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Extension.Customer.Application.ViewModels
{
    public class CustomerViewModel
    {
        /// <summary>
        /// The constant errormessage name required{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_ERRORMESSAGE_NAME_REQUIRED = "The Name is Required";
        /// <summary>
        /// The constant errormessage email required{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_ERRORMESSAGE_EMAIL_REQUIRED = "The E-mail is Required";
        /// <summary>
        /// The constant errormessage birthdate required{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_ERRORMESSAGE_BIRTHDATE_REQUIRED = "The BirthDate is Required";
        /// <summary>
        /// The constant errormessage data format invalid{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_ERRORMESSAGE_DATA_FORMAT_INVALID = "The data format is invalid";
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = CONST_ERRORMESSAGE_NAME_REQUIRED)]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required(ErrorMessage = CONST_ERRORMESSAGE_EMAIL_REQUIRED)]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        [Required(ErrorMessage = CONST_ERRORMESSAGE_BIRTHDATE_REQUIRED)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = CONST_ERRORMESSAGE_DATA_FORMAT_INVALID)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
