using System.Collections.Generic;

namespace WebApplicationNet5.Entities.Post
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        
        public ICollection<Post> Post { get; set; }
    }
}