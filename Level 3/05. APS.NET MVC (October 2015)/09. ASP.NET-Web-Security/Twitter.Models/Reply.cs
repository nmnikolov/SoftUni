namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Reply
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}