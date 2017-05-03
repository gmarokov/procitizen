using System.ComponentModel.DataAnnotations;

namespace Reporter.Web.ViewModels.User
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}