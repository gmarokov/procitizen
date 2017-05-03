using System.ComponentModel.DataAnnotations;

namespace Reporter.Web.ViewModels.User
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}