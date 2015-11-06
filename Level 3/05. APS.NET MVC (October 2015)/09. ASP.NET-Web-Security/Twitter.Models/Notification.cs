namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsRead { get; set; }
        
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}