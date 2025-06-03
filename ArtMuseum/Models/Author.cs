using System.Reflection.Metadata;

namespace ArtMuseum.Models
{
    public class Author
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }


}
