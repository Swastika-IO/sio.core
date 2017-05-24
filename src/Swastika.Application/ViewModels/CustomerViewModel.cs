using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Application.ViewModels
{
    public class CustomerViewModel
    {
        private const string CONST_ERRORMESSAGE_NAME_REQUIRED = "The Name is Required";
        private const string CONST_ERRORMESSAGE_EMAIL_REQUIRED = "The E-mail is Required";
        private const string CONST_ERRORMESSAGE_BIRTHDATE_REQUIRED = "The BirthDate is Required";
        private const string CONST_ERRORMESSAGE_DATA_FORMAT_INVALID = "The data format is invalid";
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = CONST_ERRORMESSAGE_NAME_REQUIRED)]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = CONST_ERRORMESSAGE_EMAIL_REQUIRED)]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = CONST_ERRORMESSAGE_BIRTHDATE_REQUIRED)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = CONST_ERRORMESSAGE_DATA_FORMAT_INVALID)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
