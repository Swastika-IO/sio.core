using System.ComponentModel.DataAnnotations;

namespace Swastika.Infrastructure.CrossCutting.Identity.Models.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
