using System.ComponentModel.DataAnnotations;

namespace Reporter.Web.ViewModels.User
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}