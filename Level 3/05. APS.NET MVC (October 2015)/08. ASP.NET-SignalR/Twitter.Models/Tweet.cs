namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<Reply> replies;
        private ICollection<TweetFavorite> favorites;

        public Tweet()
        {
            this.replies = new HashSet<Reply>();
            this.favorites = new HashSet<TweetFavorite>();
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
        
        [Required]
        public string WallOwnerId { get; set; }

        public virtual ApplicationUser WallOwner { get; set; }

        public virtual ICollection<Reply> Replies
        {
            get { return this.replies; }
            set { this.replies = value; }
        }

        public virtual ICollection<TweetFavorite> Favorites
        {
            get { return this.favorites; }
            set { this.favorites = value; }
        }
    }
}