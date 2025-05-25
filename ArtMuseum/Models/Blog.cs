namespace ArtMuseum.Models
{
    public class Blog : BaseEntity
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

}
