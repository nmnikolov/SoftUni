namespace Twitter.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditProfileBindingModel
    {
        [Required]
        [RegularExpression(@"^[\dA-Za-z_]{2,30}$",
            ErrorMessage = "The {0} must be between 2 and 30 characters long and contains letters, numbers or _")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Full name")]
        public string Fullname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}