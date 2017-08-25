using System.ComponentModel.DataAnnotations;

namespace Reporter.Web.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}