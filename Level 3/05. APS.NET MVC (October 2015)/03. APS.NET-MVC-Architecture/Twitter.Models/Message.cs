namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual  ApplicationUser Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }

        [Required]
        public DateTime SendedOn { get; set; }
    }
}