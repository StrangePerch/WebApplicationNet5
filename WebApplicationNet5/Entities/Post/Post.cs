using System.Collections.Generic;

namespace WebApplicationNet5.Entities.Post
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        
        public Category Category { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}