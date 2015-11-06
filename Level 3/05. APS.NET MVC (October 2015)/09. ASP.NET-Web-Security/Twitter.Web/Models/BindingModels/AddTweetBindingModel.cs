namespace Twitter.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddTweetBindingModel
    {
        [Required]
        [MinLength(2)]
        public string Content { get; set; }
    }
}