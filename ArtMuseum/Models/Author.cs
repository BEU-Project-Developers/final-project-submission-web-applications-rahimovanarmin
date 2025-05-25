using System.Reflection.Metadata;

namespace ArtMuseum.Models
{
    public class Author : BaseEntity
    {
        
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }

}
